using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        : base(connection)
            => _connection = connection;

        public void InsertUserWithRoles(User user)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    // Inserir usuário
                    var insertUserQuery = @"
                    INSERT INTO [User] (Name, Email, PasswordHash, Bio, Image, Slug)
                    VALUES (@Name, @Email, @PasswordHash, @Bio, @Image, @Slug);
                    SELECT CAST(SCOPE_IDENTITY() as int);";

                    user.Id = _connection.QuerySingle<int>(insertUserQuery, user, transaction);

                    // Inserir perfis (roles) e obter IDs
                    foreach (var role in user.Roles)
                    {
                        // Verificar se o perfil já existe
                        var existingRole = _connection.QuerySingleOrDefault<Role>(
                            "SELECT Id FROM [Role] WHERE Name = @Name",
                            new { Name = role.Name },
                            transaction);

                        if (existingRole == null)
                        {
                            // Inserir novo perfil
                            var insertRoleQuery = @"
                            INSERT INTO [Role] (Name)
                            VALUES (@Name);
                            SELECT CAST(SCOPE_IDENTITY() as int);";

                            role.Id = _connection.QuerySingle<int>(insertRoleQuery, role, transaction);
                        }
                        else
                        {
                            role.Id = existingRole.Id;
                        }

                        // Inserir na tabela de junção
                        var insertUserRoleQuery = @"
                        INSERT INTO [UserRole] (UserId, RoleId)
                        VALUES (@UserId, @RoleId);";

                        _connection.Execute(insertUserRoleQuery, new { UserId = user.Id, RoleId = role.Id }, transaction);
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public List<User> GetWithRolesString()
        {
            var query = @"
           SELECT
                [User].[Id],
                [User].[Name],
                [User].[Email],
                STRING_AGG([Role].Name, ', ') AS RolesString
           FROM
                [User]
                LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]
           GROUP BY
                [User].[Id],
                [User].[Name],
                [User].[Email]
           ORDER BY
                [User].[Id];
            ";

            using (var connection = _connection) // Certifique-se de abrir a conexão corretamente
            {
                var users = connection.Query<User>(query).ToList();
                return users;
            }
        }

        public List<User> GetWithRoles()
        {
            var query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);

                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id");
            //Spliton é divisao de tabelas ex: User - Id, Role - Id 
            return users;
        }
    }
}
