namespace Blog.Utils
{
    public class DisplayErrorMessage
    {
        private static void Message(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Pressione qualquer tecla para retornar ao menu principal.");
            Console.ReadKey();
            //Load(); // Retorna ao menu principal
        }
    }
}
