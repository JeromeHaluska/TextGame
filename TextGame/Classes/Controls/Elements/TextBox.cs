namespace Game.Controls
{
    using System.Collections.Generic;
    using Scenes;
    using OpenTK.Graphics;
    using System.Drawing;

    /// <summary>
    /// Displays a Text inside a Box.
    /// </summary>
    public class TextBox : IControl
    {
        private Scene _scene;

        private string[] _formattedText;

        public TextBox(Scene scene, int x, int y, int width, int height, string[] text, string header = "", int headerHeight = 3, Appearance? appearance = null, Color4? headerColor = null)
        {
            _scene = scene;
            Appearance = appearance == null ? DefaultAppearance : (Appearance)appearance;
            HeaderColor = headerColor == null ? Colors.HeaderColor : (Color4)headerColor;
            Text = text;
            HeaderText = header;
            HeaderHeight = headerHeight;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Gets or sets the default appearance of a <see cref="TextBox"/>.
        /// </summary>
        public static Appearance DefaultAppearance { get; set; } = new Appearance(Colors.TextColor, Colors.DarkBackgroundColor);

        public string[] Text {
            get
            {
                return _formattedText;
            }

            set
            {
                _formattedText = Format(value);
            }
        }

        public string HeaderText { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int HeaderHeight { get; set; }

        public Appearance Appearance { get; set; }

        public Color4 HeaderColor { get; set; }

        /// <summary>
        /// Formats the text for drawing.
        /// </summary>
        /// <param name="inputText">The text that gets formatted</param>
        /// <returns></returns>
        private string[] Format(string[] inputText)
        {
            var outputText = new List<string>();

            outputText.AddRange(inputText);
            return outputText.ToArray();
        }

        public void Draw()
        {
            var topLeft = new Point(X, Y);
            var bottomRight = new Point(X + Width, Y + Height);
            var headerBackgroundColor = Colors.Darken(Appearance.BackgroundColor);
            var contentOffset = 1;

            // Draw the box
            _scene.Console.FillBox(topLeft, bottomRight, Appearance.BackgroundColor);

            // Draw the header.
            if (HeaderText != "") {
                contentOffset += HeaderHeight;
                _scene.Console.FillBox(topLeft, new Point(X + Width, Y + HeaderHeight), headerBackgroundColor);
                _scene.Console.Write(Y + HeaderHeight / 2, X + 1, HeaderText);
            }

            // Draw the content.
            var cnt = 0;
            foreach (string line in Text) {
                _scene.Console.Write(Y + contentOffset + (cnt++), 1, line);
            }
        }
    }
}
