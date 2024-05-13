using Blog;
using Blog.Screens.RoleScreens;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;
using Microsoft.Data.SqlClient;

class Program
{
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true;";

    static void Main(string[] args)
    {
        Database.Connection = new SqlConnection(CONNECTION_STRING);
        Database.Connection.Open();

        Load();

        Console.ReadKey();
        Database.Connection.Close();
    }

    private static void Load()
    {
        Console.Clear();
        Console.WriteLine("Meu Blog");
        Console.WriteLine("-----------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Gestão de usuário");
        Console.WriteLine("2 - Gestão de perfil");
        Console.WriteLine("3 - Gestão de categoria");
        Console.WriteLine("4 - Gestão de tag");
        Console.WriteLine("5 - Vincular perfil/usuário");
        Console.WriteLine("6 - Vincular post/tag");
        Console.WriteLine("7 - Relatórios");
        Console.WriteLine();
        Console.WriteLine();
        // Captura a entrada do usuário
        var input = Console.ReadLine();

        // Verifica se a entrada é um número válido
        if (short.TryParse(input, out short option))
        {
            switch (option)
            {
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 2:
                    MenuRoleScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                default:   // Se a opção não for válida, exibe uma mensagem de erro e volta ao menu
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    Load(); // Retorna ao menu principal
                    break;
            }
        }
        else
        {
            // Se a entrada não for um número válido, exibe uma mensagem de erro e volta ao menu
            Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
            Load(); // Retorna ao menu principal
        }

    }
}