using OpenTK.Graphics;
using System.Collections.Generic;

namespace Game.Controls
{
    /// <summary>
    /// Displays a Text inside a Box.
    /// </summary>
    public class TextBox : IControl
    {
        private string[] _formattedText;

        public TextBox(ExtendedConsoleWindow console, int x, int y, int width, int height, string[] text, string header = "", Appearance? appearance = null, Color4? headerColor = null)
        {
            Appearance = appearance == null ? DefaultAppearance : (Appearance)appearance;
            HeaderColor = headerColor == null ? Colors.HeaderColor : (Color4)headerColor;
            Text = text;
            Header = header;
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

        public string Header { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

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
            if (Header != "") {

            }
        }
    }
}
