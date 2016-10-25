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

            // Dev Test: DialogueBox
            DialogueBox.Delay = 5;
            var dBox = new DialogueBox(this, 18, 1, 61, 23, Colors.TextColor);
            dBox.WriteSlow("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis. At vero eos et accusam et justo duo dolores et ea rebum.Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.At vero eos et accusam et justo duo dolores et ea rebum.Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet, consetetur sadipscing elitr, At accusam aliquyam diam diam dolore dolores duo eirmod eos erat, et nonumy sed tempor et et invidunt justo labore Stet clita ea et gubergren, kasd magna no rebum.sanctus sea sed takimata ut vero voluptua.est Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet, consetetur");
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
