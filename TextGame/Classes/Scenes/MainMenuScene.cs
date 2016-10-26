namespace Game.Scenes
{
    using Controls;
    using OpenTK.Graphics;
    using Utility;

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

            // Rainbow Text with Dialogue Box.
            DialogueBox.Delay = 1;
            var dBox = new DialogueBox(this, 18, 1, 61, 23);
            var colString = new ColoredString("");
            var gradientColString = new ColoredString("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.");
            for (int cnt = 0; cnt < 10; cnt++) {
                gradientColString.AddGradient(Color4.Yellow, Color4.Green, true);
                colString += gradientColString;
                gradientColString.AddGradient(Color4.Green, Color4.Blue, true);
                colString += gradientColString;
                gradientColString.AddGradient(Color4.Blue, Color4.Violet, true);
                colString += gradientColString;
                gradientColString.AddGradient(Color4.Violet, Color4.Red, true);
                colString += gradientColString;
                gradientColString.AddGradient(Color4.Red, Color4.Yellow, true);
                colString += gradientColString;
            }
            dBox.Write(colString);
            Add(dBox);
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
