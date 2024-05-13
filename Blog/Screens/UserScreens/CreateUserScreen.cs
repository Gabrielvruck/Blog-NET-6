using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova usuário");
            Console.WriteLine("-------------");
            Console.Write("Nome: ");
            var name = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Senha: ");
            var passwordHash = Console.ReadLine();
            Console.Write("Bio: ");
            var bio = Console.ReadLine();
            Console.Write("Image: ");
            var image = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Create(new User
            {
                Name = name,
                Email = email,
                PasswordHash = passwordHash,
                Bio = bio,
                Image = image,
                Slug = slug
            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Create(user);
                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
