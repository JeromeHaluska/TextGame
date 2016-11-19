namespace Game
{
    using System.Threading;
    using Draw;
    using Scenes;

    class Program
    {
        static void Main()
        {
            var console = new ExtendedConsoleWindow(25, 80, "Gloria");

            console.ActiveScene = new MainMenuScene();

            // Main game loop
            while (console.WindowUpdate()) {
                Thread.Sleep(10);
            }
        }
    }
}
