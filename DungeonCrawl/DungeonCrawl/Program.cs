namespace DungeonCrawl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Art.PrintChurch();

            GameManager gm = new GameManager();
            gm.RunGame();
        }
    }
}