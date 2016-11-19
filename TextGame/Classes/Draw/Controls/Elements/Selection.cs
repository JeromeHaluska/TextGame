namespace Draw.Controls
{
    using System;
    using System.Collections.Generic;
    using Default;

    /// <summary>
    /// A selection can be used to choose between different things.
    /// </summary>
    public class Selection : IControl
    {
        private List<Button> _buttonList = new List<Button>();

        private int _x;

        private int _y;

        private int _fixedWidth;

        private int _minSelectedItems;

        private int _maxSelectedItems;

        private int _selectedItems;

        public Selection(int x, int y, int fixedWidth = 0, int minSelectedItems = 1, int maxSelectedItems = 1)
        {
            X = x;
            Y = y;
            FixedWidth = fixedWidth;
            MinSelectedItems = minSelectedItems;
            MaxSelectedItems = maxSelectedItems;
        }

        public delegate void SelectionEventHandler(object source, SelectionEventArgs args);

        /// <summary>
        /// Fired when the selection is valid. For a definition of valid see <see cref="IsValid"/>.
        /// </summary>
        public event SelectionEventHandler Valid;

        /// <summary>
        /// Fired when the selection is NOT valid. For a definition of valid see <see cref="IsValid"/>.
        /// </summary>
        public event EventHandler NotValid;
        
        /// <summary>
        /// Fired when the mouse enters the selection. Returns the item that is hovered.
        /// </summary>
        public event SelectionEventHandler MouseEnter;

        public int X
        {
            get
            {
                return _x;
            }

            private set
            {
                _x = Math.Max(value, 0);
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }

            private set
            {
                _y = Math.Max(value, 0);
            }
        }

        /// <summary>
        /// Gets or sets the width of the selection.
        /// </summary>
        public int FixedWidth
        {
            get
            {
                return _fixedWidth;
            }

            set
            {
                _fixedWidth = value;
                foreach (Button button in _buttonList) {
                    button.FixedWidth = _fixedWidth;
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum selected items.
        /// </summary>
        public int MinSelectedItems
        {
            get
            {
                return _minSelectedItems;
            }

            set
            {
                _minSelectedItems = Math.Max(value, 1);
            }
        }

        /// <summary>
        /// Gets or sets the maximum selected items.
        /// </summary>
        public int MaxSelectedItems
        {
            get
            {
                return _maxSelectedItems;
            }

            set
            {
                _maxSelectedItems = Math.Max(value, 1);
            }
        }

        /// <summary>
        /// Gets the state of the selection. Returns true if the minimum and maximum selection requirement is fulfilled.
        /// </summary>
        public bool IsValid { get; private set; } = false;

        public void AddItem(string text)
        {
            var newButton = new Button(X, Y + _buttonList.Count, 1, text);

            // Change the colors of the item.
            newButton.SetColors(DefaultSelection.TextColor, DefaultSelection.BackgroundColor);

            // Subscribing to the button Click event.
            newButton.Click += (source, args) => {
                if (!newButton.IsHighlighted && _selectedItems < MaxSelectedItems) {
                    _selectedItems++;
                    newButton.IsHighlighted = true;
                } else if (newButton.IsHighlighted) {
                    _selectedItems--;
                    newButton.IsHighlighted = false;
                }

                if (_selectedItems >= MinSelectedItems && _selectedItems <= MaxSelectedItems) {
                    IsValid = true;

                    // Create a list with all selected Items.
                    var itemList = new List<string>();

                    foreach (Button button in _buttonList) {
                        if (button.IsHighlighted) {
                            itemList.Add(button.Text);
                        }
                    }

                    // Firing the Valid event.
                    Valid?.Invoke(this, new SelectionEventArgs(itemList));
                } else {
                    IsValid = false;

                    // Firing the NotValid event.
                    NotValid?.Invoke(this, EventArgs.Empty);
                }
            };

            // Subscribing to the button MouseEnter event.
            newButton.MouseEnter += (source, args) => {
                var buttonText = new List<string>();

                buttonText.Add(newButton.Text);
                MouseEnter?.Invoke(this, new SelectionEventArgs(buttonText));
            };

            newButton.FixedWidth = FixedWidth;
            _buttonList.Add(newButton);
        }

        /// <summary>
        /// Draws every item in the selection.
        /// </summary>
        public void Draw()
        {
            // Check if the Selection is valid.
            if (_buttonList.Count < MaxSelectedItems) {
                throw new Exception("The selection MaxSelectedItems property is higher then the actual number of items.");
            }

            // Draw every item in the selection.
            foreach (Button button in _buttonList) {
                button.Draw();
            }
        }
    }

    public class SelectionEventArgs : EventArgs {
        public SelectionEventArgs(List<string> itemList)
        {
            ItemList = itemList;
        }

        public List<string> ItemList { get; set; }
    }
}
