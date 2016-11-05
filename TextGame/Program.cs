namespace Game
{
    using System.Threading;
    using Draw;
    using Draw.Scenes;

    class Program
    {
        static void Main()
        {
            var activeConsole = new ExtendedConsoleWindow(25, 80, "Gloria");
            
            activeConsole.ActiveScene = new MainMenuScene(activeConsole);

            // Main game loop
            while (activeConsole.WindowUpdate()) {
                Thread.Sleep(10);
            }
        }
    }
}
