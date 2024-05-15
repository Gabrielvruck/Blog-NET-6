using Blog.Screens.RoleScreens;
using Blog.Screens.TagScreens;

namespace Blog.Screens.UserScreens
{
    public class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de usuários");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar usuários");
            Console.WriteLine("2 - Listar usuário e perfis");
            Console.WriteLine("3 - Listar usuários e perfil");
            Console.WriteLine("4 - Cadastrar usuári");
            Console.WriteLine("5 - Atualizar usuário");
            Console.WriteLine("6 - Excluir usuário");
            Console.WriteLine();
            Console.WriteLine();

            // Captura a entrada do usuário
            var input = Console.ReadLine();

            // Verifica se a entrada é um número válido
            if (short.TryParse(input, out short option))
            {
                HandleOption(option);
            }
            else
            {
                // Se a entrada não for um número válido, exibe uma mensagem de erro
                DisplayErrorMessage("Opção inválida. Por favor, escolha uma opção válida.");
            }
        }
        private static void HandleOption(short option)
        {
            switch (option)
            {
                case 1:
                    ListUserScreen.Load();
                    break;
                case 2:
                    ListUserRoleStringScreen.Load();
                    break;
                case 3:
                    ListUserRoleScreen.Load();
                    break;
                case 4:
                    CreateUserScreen.Load();
                    break;
                case 5:
                    UpdateUserScreen.Load();
                    break;
                case 6:
                    DeleteUserScreen.Load();
                    break;
                default:
                    // Se a opção não for válida, exibe uma mensagem de erro
                    DisplayErrorMessage("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }

        private static void DisplayErrorMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
            Load(); // Retorna ao menu principal
        }
    }
}
