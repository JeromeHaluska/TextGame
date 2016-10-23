namespace Game.Scenes
{
    using Controls;
    using OpenTK.Graphics;

    /// <summary>
    /// The main menu of the game.
    /// </summary>
    public class MainMenuScene : Scene
    {
        public MainMenuScene(ExtendedConsoleWindow console) : base(console)
        {
            var buttonFixedWidth = 15;
            var button1 = new Button(this, 1, 3, 3, "New Game");
            var button2 = new Button(this, 1, 7, 3, "Load Game");
            var button3 = new Button(this, 1, 11, 3, "Options");
            var button4 = new Button(this, 1, Console.Rows - 4, 3, "Exit");

            button1.FixedWidth = buttonFixedWidth;
            button1.Click += (source, args) => {
                Console.ActiveScene = new CharacterCreationScene(Console);
                return;
            };

            button2.IsActive = false;
            button2.FixedWidth = buttonFixedWidth;

            button3.IsActive = false;
            button3.FixedWidth = buttonFixedWidth;

            button4.Appearance = new Appearance(Color4.LightGray, Color4.Crimson);
            button4.FixedWidth = buttonFixedWidth;
            button4.Click += (source, args) => {
                Console.CloseWindow = true;
            };

            Add(button1);
            Add(button2);
            Add(button3);
            Add(button4);
        }
        
        public override void Draw()
        {
            // Filling the background.
            Console.Fill(Colors.BackgroundColor);

            // Drawing all controls.
            base.Draw();

            Console.Write(1, 1, "Main Menu", Colors.HeaderColor, null);
        }
    }
}
