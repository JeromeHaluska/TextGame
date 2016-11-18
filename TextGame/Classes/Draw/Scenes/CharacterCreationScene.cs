namespace Draw.Scenes
{
    using System.Collections.Generic;
    using Draw.Controls;
    using Draw;

    public class CharacterCreationScene : Scene
    {
        private Dictionary<string, string[]> _pathToDescription = new Dictionary<string, string[]>();

        public CharacterCreationScene() : base()
        {
            var confirmButton = new Button(1, Console.Rows - 4, 3, "Confirm");
            var pathSelection = new Selection(1, 3, 25, 1, 1);
            var pathDescriptionBox = new TextBox(36, 0, Console.Cols - 37, Console.Rows - 1, new string[0], "Hover over a path for a description");

            // Fill dictionary with descriptions of the different paths. (Shouldn't be in here)
            _pathToDescription.Add("Brute", new string[] {
                "The brute is a fierce fighter. " +
                "He has no interrest in magic. " +
                "His attacks are relatively imprecise " +
                "BUT fatal! His uncontrollable anger " +
                "brings enemies to shiver in fear. " +
                "His thick, leathery skin " +
                "helps him to stay on his foot. ",
                "",
                "Path:",
                "Brute -> Mercenary -> Barbarian"
            });
            _pathToDescription.Add("Gravedigger", new string[] {
                "He really likes his job.",
                "",
                "Path:",
                "Gravedigger -> Cultist -> Summoner"
            });
            _pathToDescription.Add("Scum", new string[] {
                "What the scum doesn't achieve through his tactical thinking " +
                "he gets with a cheap trick or two.",
                "",
                "Thats the reason why he isn't very popular with people," +
                " but he earns their fear and thats atleast something.",
                "",
                "Path:",
                "Scum -> Thief -> Assassin"
            });

            pathSelection.AddItem("Brute");
            pathSelection.AddItem("Gravedigger");
            pathSelection.AddItem("Scum");

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
