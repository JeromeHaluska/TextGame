namespace Game.Controls
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using OpenTK.Graphics;
    using OpenTK.Input;
    using Scenes;

    public class Button : IControl
    {
        private Scene _scene;

        private Bounds _bounds;

        private int _x;

        private int _y;

        private int _fixedWidth = 0;

        private int _height;

        private string _text = string.Empty;
        
        private bool _isHovered = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="console">Console that should be used.</param>
        /// <param name="x">Button x-position.</param>
        /// <param name="y">Button y-position.</param>
        /// <param name="height">Button height.</param>
        /// <param name="text">The displayed text on the button.</param>
        /// <param name="appearance">Button appearance. <see cref="DefaultAppearance"/> is used if null</param>
        public Button(Scene scene, int x, int y, int height, string text, Appearance? appearance = null)
        {
            _scene = scene;
            Text = text;
            Height = height;
            X = x;
            Y = y;
            Appearance = appearance == null ? DefaultAppearance : appearance.GetValueOrDefault();

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
        /// Gets or sets the default appearance of a <see cref="Button"/>.
        /// </summary>
        public static Appearance DefaultAppearance { get; set; } = new Appearance(Colors.TextColor, Colors.SecondaryColor);

        /// <summary>
        /// Gets or sets the button appearance.
        /// </summary>
        public Appearance Appearance { get; set; }

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

        /// <summary>
        /// Draws the button on the console.
        /// </summary>
        public void Draw()
        {
            Color4 textColor, backgroundColor;

            // Assign colors based on the button state
            textColor = IsActive ? !IsHighlighted ? _isHovered ? Appearance.HoverTextColor : Appearance.TextColor : Appearance.HighlightTextColor : Appearance.DisabledTextColor;
            backgroundColor = IsActive ? !IsHighlighted ? _isHovered ? Appearance.HoverBackgroundColor : Appearance.BackgroundColor : Appearance.HighlightBackgroundColor : Appearance.DisabledBackgroundColor;

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
