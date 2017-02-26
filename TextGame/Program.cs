// Ideas:
// - Body Parts only determine hitchance, and have a damagemultiplier
// - You get a message at the beginning of a fight if your enemy is way to strong
// - To fight the first enemys you need to be very good prepared and buy items from the town.
// - After your first fight with a weak boar you wake up in a tavern you got help.
// - PlayerEventComponent (OnSell, OnBuy, OnLoot, OnUse, OnEquip, OnLevelUp)
// - ItemEventComponent (OnSell, OnUse)
// - Social skills are represented in lower numbers (1, 2, 3). Some interactions require those skills

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
            //try {
                while (console.WindowUpdate()) {
                    Thread.Sleep(10);
                }
            /*} catch (Exception e) {
                console.ActiveScene = new ExceptionScene(e);
                while (console.WindowUpdate()) {
                    Thread.Sleep(10);
                }
            }*/
        }
    }
}
