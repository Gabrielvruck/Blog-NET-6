using Blog.Models;
using Blog.Repositories;
using System.Data;

namespace Blog.Screens.UserScreens
{
    public class ListUserRoleStringScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de usuário e perfis");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void List()
        {
            var repository = new UserRepository(Database.Connection);
            var users = repository.GetWithRolesString();
            foreach (var item in users)
            {
                Console.WriteLine($"{item.Id} - {item.Name} - ({item.Email}) - {item.RolesString}");
            }
        }
    }
}
