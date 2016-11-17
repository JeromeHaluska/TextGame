namespace Draw.Controls
{
    using System;
    using System.Drawing;
    using OpenTK.Input;
    using Scenes;
    using Default;
    using OpenTK.Graphics;

    public class Button : IControl
    {
        private ExtendedConsoleWindow _console;

        /// <summary>
        /// Holds the scene that was active the moment this object was created.
        /// </summary>
        private Scene _scene;

        private Bounds _bounds;
        private int _x;
        private int _y;
        private int _fixedWidth = 0;
        private int _height;

        private string _text;
        
        private bool _isHovered = false;

        // Colors
        public Color4? TextColor { get; set; } = null;
        public Color4? BackgroundColor { get; set; } = null;
        public Color4? HoverTextColor { get; set; } = null;
        public Color4? HoverBackgroundColor { get; set; } = null;
        public Color4? DisabledTextColor { get; set; } = null;
        public Color4? DisabledBackgroundColor { get; set; } = null;
        public Color4? HighlightTextColor { get; set; } = null;
        public Color4? HighlightBackgroundColor { get; set; } = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="x">Button x-position.</param>
        /// <param name="y">Button y-position.</param>
        /// <param name="height">Button height.</param>
        /// <param name="text">The displayed text on the button.</param>
        public Button(int x, int y, int height, string text)
        {
            _console = ExtendedConsoleWindow.Console;
            Text = text;
            Height = height;
            X = x;
            Y = y;

            // Subscribe to the ButtonDown Event to determine if the button got clicked
            _console.Mouse.ButtonDown += (source, args) => {
                if (Click != null && _console.ActiveScene == _scene && IsActive && _isHovered && args.Button == MouseButton.Left) {
                    Click(this, EventArgs.Empty);
                }
            };

            // Subscribes to the Move Event to determine if the button is hovered
            _console.Mouse.Move += (source, args) => {
                if (_bounds.Contains(args.Position)) {
                    if (!_isHovered) {
                        MouseEnter?.Invoke(this, EventArgs.Empty);
                    }
                    _isHovered = true;
                } else {
                    _isHovered = false;
                }
            };
        }

        /// <summary>
        /// Fired when the button gets clicked.
        /// </summary>
        public event EventHandler Click;

        /// <summary>
        /// Fired when the button gets hovered.
        /// </summary>
        public event EventHandler MouseEnter;

        /// <summary>
        /// Gets or sets the x-position.
        /// </summary>
        public int X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = Math.Max(value, 0);
                RecalculateBounds();
            }
        }

        /// <summary>
        /// Gets or sets the y-position.
        /// </summary>
        public int Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = Math.Max(value, 0);
                RecalculateBounds();
            }
        }

        /// <summary>
        /// Gets or sets the button height.
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value % 2 != 0 ? value : _height;
                RecalculateBounds();
            }
        }

        /// <summary>
        /// Gets or sets the button width to a fixed number.
        /// </summary>
        public int FixedWidth
        {
            get
            {
                return _fixedWidth;
            }

            set
            {
                if (value > 0) {
                    _fixedWidth = value;
                    RecalculateBounds();
                }
            }
        }

        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
                RecalculateBounds();
            }
        }

        public bool HasPadding { get; set; } = true;

        public bool IsActive { get; set; } = true;

        public bool IsHighlighted { get; set; } = false;

        public void SetColors(Color4 textColor, Color4 backgroundColor)
        {
            TextColor = textColor;
            BackgroundColor = backgroundColor;
            HoverTextColor = Colors.Lighten((Color4)TextColor);
            HoverBackgroundColor = Colors.Lighten((Color4)BackgroundColor);
            DisabledTextColor = Colors.Darken((Color4)TextColor);
            DisabledBackgroundColor = Colors.Darken((Color4)BackgroundColor);
            HighlightTextColor = Colors.Invert((Color4)TextColor);
            HighlightBackgroundColor = Colors.Invert((Color4)BackgroundColor);
        }

        /// <summary>
        /// Draws the button on the console.
        /// </summary>
        public void Draw()
        {
            Color4 textColor, backgroundColor;

            // Needs to be here for correct mouse input.
            _scene = ExtendedConsoleWindow.Console.ActiveScene != _scene ? ExtendedConsoleWindow.Console.ActiveScene : _scene;

            // Assign colors based on the button state.
            if (IsActive) {
                if (!IsHighlighted) {
                    if (_isHovered) {
                        textColor = HoverTextColor == null ? DefaultButton.HoverTextColor : (Color4)HoverTextColor;
                        backgroundColor = HoverTextColor == null ? DefaultButton.HoverBackgroundColor : (Color4)HoverBackgroundColor;
                    } else {
                        textColor = TextColor == null ? DefaultButton.TextColor : (Color4)TextColor;
                        backgroundColor = BackgroundColor == null ? DefaultButton.BackgroundColor : (Color4)BackgroundColor;
                    }
                } else {
                    textColor = HighlightTextColor == null ? DefaultButton.HighlightTextColor : (Color4)HighlightTextColor;
                    backgroundColor = HighlightBackgroundColor == null ? DefaultButton.HighlightBackgroundColor : (Color4)HighlightBackgroundColor;
                }
            } else {
                textColor = DisabledTextColor == null ? DefaultButton.DisabledTextColor : (Color4)DisabledTextColor;
                backgroundColor = DisabledBackgroundColor == null ? DefaultButton.DisabledBackgroundColor : (Color4)DisabledBackgroundColor;
            }

            // Draw the button on the console.
            _console.FillBox(new Point(X, Y), new Point(X + (FixedWidth > 0 ? FixedWidth : (" " + Text + " ").Length), Y + Height - 1), backgroundColor);
            _console.Write(
                    Y + Height / 2,
                    X,
                    " " + Text,
                    textColor,
                    backgroundColor);
        }

        private void RecalculateBounds()
        {
            var buttonTopLeft = new Point(X * _console.FontWidth, Y * _console.FontHeight);
            var buttonBottomRight = new Point((X + (FixedWidth <= 0 ? Text.Length + 2 : FixedWidth)) * _console.FontWidth, (Y + Height) * _console.FontHeight);

            _bounds = new Bounds(buttonTopLeft, buttonBottomRight);
        }
    }
}
