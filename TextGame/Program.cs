namespace Game
{
    using System.Threading;
    using Draw;
    using Scenes;
    using System;

    class Program
    {
        static void Main()
        {
            var console = new ExtendedConsoleWindow(25, 80, "Gloria");

            console.ActiveScene = new MainMenuScene();

            // Main game loop
            try {
                while (console.WindowUpdate()) {
                    Thread.Sleep(10);
                }
            } catch (Exception e) {
                console.ActiveScene = new ExceptionScene(e);
                while (console.WindowUpdate()) {
                    Thread.Sleep(10);
                }
            }
        }
    }
}
