namespace SpaCrawler.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Startup.Main().GetAwaiter().GetResult();
        }
    }
}