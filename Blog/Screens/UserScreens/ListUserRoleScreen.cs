using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class ListUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de usuários e perfis");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void List()
        {
            var repository = new UserRepository(Database.Connection);
            var users = repository.GetWithRoles();
            foreach (var item in users)
            {
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($"{item.Id} - {item.Name} - ({item.Email}) - {role.Name}");
                }
            }
        }
    }
}
