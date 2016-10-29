namespace Game.Controls
{
    using System;
    using System.Drawing;
    using OpenTK.Input;
    using Scenes;
    using Default;
    using OpenTK.Graphics;

    public class Button : IControl
    {
        private Scene _scene;

        private Bounds _bounds;
        private int _x;
        private int _y;
        private int _fixedWidth = 0;
        private int _height;

        private string _text;
        
        private bool _isHovered = false;

        // Colors
        public Color4 TextColor { get; set; }
        public Color4 BackgroundColor { get; set; }
        public Color4 HoverTextColor { get; set; }
        public Color4 HoverBackgroundColor { get; set; }
        public Color4 DisabledTextColor { get; set; }
        public Color4 DisabledBackgroundColor { get; set; }
        public Color4 HighlightTextColor { get; set; }
        public Color4 HighlightBackgroundColor { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="console">Console that should be used.</param>
        /// <param name="x">Button x-position.</param>
        /// <param name="y">Button y-position.</param>
        /// <param name="height">Button height.</param>
        /// <param name="text">The displayed text on the button.</param>
        public Button(Scene scene, int x, int y, int height, string text)
        {
            _scene = scene;
            Text = text;
            Height = height;
            X = x;
            Y = y;

            // Subscribe to the ButtonDown Event to determine if the button got clicked
            _scene.Console.Mouse.ButtonDown += (source, args) => {
                if (Click != null && _scene.Console.ActiveScene == _scene && IsActive && _isHovered && args.Button == MouseButton.Left) {
                    Click(this, EventArgs.Empty);
                }
            };

            // Subscribes to the Move Event to determine if the button is hovered
            _scene.Console.Mouse.Move += (source, args) => {
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
            HoverTextColor = Colors.Lighten(TextColor);
            HoverBackgroundColor = Colors.Lighten(BackgroundColor);
            DisabledTextColor = Colors.Darken(TextColor);
            DisabledBackgroundColor = Colors.Darken(BackgroundColor);
            HighlightTextColor = Colors.Invert(TextColor);
            HighlightBackgroundColor = Colors.Invert(BackgroundColor);
        }

        /// <summary>
        /// Draws the button on the console.
        /// </summary>
        public void Draw()
        {
            Color4 textColor, backgroundColor;

            // Assign colors based on the button state
            if (IsActive) {
                if (!IsHighlighted) {
                    if (_isHovered) {
                        textColor = HoverTextColor == null ? DefaultButton.HoverTextColor : HoverTextColor;
                        backgroundColor = HoverTextColor == null ? DefaultButton.HoverBackgroundColor : HoverBackgroundColor;
                    } else {
                        textColor = TextColor == null ? DefaultButton.TextColor : TextColor;
                        backgroundColor = BackgroundColor == null ? DefaultButton.BackgroundColor : BackgroundColor;
                    }
                } else {
                    textColor = HighlightTextColor == null ? DefaultButton.HighlightTextColor : HighlightTextColor;
                    backgroundColor = HighlightBackgroundColor == null ? DefaultButton.HighlightBackgroundColor : HighlightBackgroundColor;
                }
            } else {
                textColor = DisabledTextColor == null ? DefaultButton.DisabledTextColor : DisabledTextColor;
                backgroundColor = DisabledBackgroundColor == null ? DefaultButton.DisabledBackgroundColor : DisabledBackgroundColor;
            }
            //var textColor = IsActive ? !IsHighlighted ? _isHovered ? DefaultButton.HoverTextColor : DefaultButton.TextColor : DefaultButton.HighlightTextColor : DefaultButton.DisabledTextColor;
            //var backgroundColor = IsActive ? !IsHighlighted ? _isHovered ? DefaultButton.HoverBackgroundColor : DefaultButton.BackgroundColor : DefaultButton.HighlightBackgroundColor : DefaultButton.DisabledBackgroundColor;

            // Draw the button on the console
            _scene.Console.FillBox(new Point(X, Y), new Point(X + (FixedWidth > 0 ? FixedWidth : (" " + Text + " ").Length), Y + Height - 1), backgroundColor);
            _scene.Console.Write(
                    Y + Height / 2,
                    X,
                    " " + Text,
                    textColor,
                    backgroundColor);
        }

        private void RecalculateBounds()
        {
            var buttonTopLeft = new Point(X * _scene.Console.FontWidth, Y * _scene.Console.FontHeight);
            var buttonBottomRight = new Point((X + (FixedWidth <= 0 ? Text.Length + 2 : FixedWidth)) * _scene.Console.FontWidth, (Y + Height) * _scene.Console.FontHeight);

            _bounds = new Bounds(buttonTopLeft, buttonBottomRight);
        }
    }
}
