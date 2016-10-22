namespace Game.Scenes
{
    using System.Collections.Generic;
    using Controls;
    using System.Drawing;

    public class CharacterCreationScene : Scene
    {
        private string _hoveredPath = "";
        private Dictionary<string, string[]> _pathToDescription = new Dictionary<string, string[]>();

        public CharacterCreationScene(ExtendedConsoleWindow console) : base(console)
        {
            var confirmButton = new Button(this, 1, Console.Rows - 4, 3, "Confirm");
            var pathSelection = new Selection(this, 1, 3, 25, 1, 1);

            // Fill dictionary with descriptions of the different paths.
            _pathToDescription.Add("Brute", new string[] {
                "The brute is a fierce fighter.",
                "He has no interrest in magic.",
                "His attacks are relatively imprecise",
                "BUT fatal! His uncontrollable anger",
                "brings enemies to shiver in fear.",
                "His thick, leathery skin",
                "helps him to stay on his foot."
            });
            _pathToDescription.Add("Gravedigger", new string[] {
                "... (he doesn't talk much)",
            });
            _pathToDescription.Add("Loremaster", new string[] {
                "Very interested in books!",
            });

            pathSelection.AddItem("Brute");
            pathSelection.AddItem("Gravedigger");
            pathSelection.AddItem("Loremaster");

            // Enables the confirm button if the selection is valid.
            pathSelection.Valid += (source, args) => {
                confirmButton.IsActive = true;
            };

            // Disables the confirm button if the selection is invalid.
            pathSelection.NotValid += (source, args) => {
                confirmButton.IsActive = false;
            };

            // Update the hovered path if the mouse hovers over a item.
            pathSelection.MouseEnter += (source, args) => {
                _hoveredPath = args.ItemList[0];
            };
            
            confirmButton.IsActive = false;

            // Add controlls to the screen.
            Add(pathSelection);
            Add(confirmButton);
        }

        public override void Draw()
        {
            // Filling the background.
            Console.Fill(Colors.BackgroundColor);

            // Drawing all controls.
            base.Draw();

            Console.Write(1, 1, "Choose a path", Colors.HeaderColor, null);
            Console.FillBox(new Point(36, 0), new Point(Console.Cols - 1, Console.Rows - 1), Colors.DarkBackgroundColor);

            // Drawing a description of the currently hovered path.
            if (_hoveredPath != string.Empty) {
                var hoveredPathDescription = _pathToDescription[_hoveredPath];

                Console.Write(1, 37, _hoveredPath, Colors.HeaderColor, null);
                for (int cnt = 0; cnt < hoveredPathDescription.Length; cnt++) {
                    Console.Write(cnt + 3, 37, hoveredPathDescription[cnt], Colors.TextColor, null);
                }
            }
        }
    }
}
