namespace Draw.Scenes
{
    using System.Collections.Generic;
    using Draw.Controls;
    using Draw;

    public class CharacterCreationScene : Scene
    {
        private Dictionary<string, string[]> _pathToDescription = new Dictionary<string, string[]>();

        public CharacterCreationScene(ExtendedConsoleWindow console) : base(console)
        {
            var confirmButton = new Button(this, 1, Console.Rows - 4, 3, "Confirm");
            var pathSelection = new Selection(this, 1, 3, 25, 1, 1);
            var pathDescriptionBox = new TextBox(this, 36, 0, Console.Cols - 37, Console.Rows - 1, new string[0], "Hover over a path for a description");

            // Fill dictionary with descriptions of the different paths.
            _pathToDescription.Add("Brute", new string[] {
                "The brute is a fierce fighter. " +
                "He has no interrest in magic. " +
                "His attacks are relatively imprecise " +
                "BUT fatal! His uncontrollable anger " +
                "brings enemies to shiver in fear. " +
                "His thick, leathery skin " +
                "helps him to stay on his foot. ",
                "",
                "This should be a new paragraph!"
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
                var hoveredPath = args.ItemList[0];

                pathDescriptionBox.HeaderText = hoveredPath;
                pathDescriptionBox.FormatText(_pathToDescription[hoveredPath]);
            };
            
            confirmButton.IsActive = false;

            // Add controlls to the screen.
            Add(pathSelection);
            Add(confirmButton);
            Add(pathDescriptionBox);
        }

        public override void Draw()
        {
            // Filling the background.
            Console.Fill(Colors.BackgroundColor);

            // Drawing all controls.
            base.Draw();

            Console.Write(1, 1, "Choose a path", Colors.HeaderColor, null);
        }
    }
}
