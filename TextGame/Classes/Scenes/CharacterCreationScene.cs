namespace Game.Scenes
{
    using System.Collections.Generic;
    using Draw;
    using Draw.Controls;
    using Draw.Utility;
    using Paths;
    using Entities;
    using Races;

    public class CharacterCreationScene : Scene
    {
        private Button _confirmButton;

        private Path _chosenPath;
        private Race _chosenRace;

        private Dictionary<string, string[]> _pathToDescription = new Dictionary<string, string[]>();

        public CharacterCreationScene() : base()
        {
            _confirmButton = new Button(1, Console.Rows - 4, 3, "Confirm");
            _confirmButton.IsActive = false;

            // Add controlls to the screen.
            Add(_confirmButton);

            InitPathSelection();
        }

        private void InitPathSelection()
        {
            var pathSelection = new Selection(1, 3, 25, 1, 1);
            var pathDescriptionBox = new TextBox(36, 0, Console.Cols - 37, Console.Rows - 1, new string[0], "Hover over a path for a description");

            // Fill dictionary with descriptions of the different paths and add them to the selection.
            var paths = Path.GetAllPaths();

            foreach (Path path in paths) {
                var pathName = path.GetName(1);

                _pathToDescription.Add(pathName, path.Description);
                pathSelection.AddItem(pathName);
            }

            // Enables the confirm button if the selection is valid.
            pathSelection.Valid += (source, args) => {
                _confirmButton.IsActive = true;
            };

            // Disables the confirm button if the selection is invalid.
            pathSelection.NotValid += (source, args) => {
                _confirmButton.IsActive = false;
            };

            // Update the hovered path if the mouse hovers over a item.
            pathSelection.MouseEnter += (source, args) => {
                var hoveredPath = args.ItemList[0];

                pathDescriptionBox.HeaderText = hoveredPath;
                pathDescriptionBox.FormatText(_pathToDescription[hoveredPath]);
            };

            _confirmButton.Click += (source, args) => {
                _chosenPath = Path.GetPath(pathSelection.SelectedItems[0], 1);
                InitRaceSelection();
            };

            Add(pathSelection);
            Add(pathDescriptionBox);
        }

        private void InitRaceSelection()
        {
            ResetControls();
            Add(_confirmButton);
            _chosenRace = new Human();
        }

        private void InitCharacterCreation()
        {
            Game.Player = new Player("Max Mustermann", _chosenRace);
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
