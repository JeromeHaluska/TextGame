namespace Game.Controls
{
    using System.Collections.Generic;
    using Scenes;
    using OpenTK.Graphics;
    using System.Drawing;
    using Utility;
    using Default;

    /// <summary>
    /// Displays a Text inside a Box.
    /// </summary>
    public class TextBox : IControl
    {
        private Scene _scene;

        private ColoredString[] _formattedText;

        public TextBox(Scene scene, int x, int y, int width, int height, string[] lines, string header = "", int headerHeight = 3, Color4? headerColor = null)
        {
            _scene = scene;
            FormatText(ColoredString.ToArray(lines));
            HeaderText = header;
            HeaderHeight = headerHeight;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public string HeaderText { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int HeaderHeight { get; set; }

        /// <summary>
        /// Formats the text for drawing.
        /// </summary>
        /// <param name="inputText">The text that gets formatted</param>
        /// <returns></returns>
        public void FormatText(ColoredString[] inputText)
        {
            var outputText = new List<ColoredString>();

            // Make sure that every line is inside the text box.
            for (int cnt = 0; cnt < inputText.Length; cnt++) {
                var colString = inputText[cnt];

                while (colString.Length > Width - 2) {
                    int wordOffset;

                    // Check if a word gets cut of and determine the index before the word, to prevent cutting it of.
                    for (wordOffset = 0; Width - 1 - wordOffset >= 0; wordOffset++) {
                        var colChar = colString[Width - 1 - wordOffset - 1];
                        
                        if (colChar.Value == ' ') {
                            break;
                        }
                    }

                    // Get the part of the current line that gets not cut off.
                    var shortenedColString = colString.Substring(0, Width - 1 - wordOffset);
                    outputText.Add(shortenedColString);

                    // Get the part that got cut off.
                    colString = colString.Substring(Width - 1 - wordOffset);
                }
                outputText.Add(colString);
            }

            _formattedText = outputText.ToArray();
        }

        public void FormatText(string[] inputText)
        {
            FormatText(ColoredString.ToArray(inputText, DefaultTextBox.TextColor, DefaultTextBox.BackgroundColor));
        }

        public void Draw()
        {
            var topLeft = new Point(X, Y);
            var bottomRight = new Point(X + Width, Y + Height);
            var contentOffset = 1;

            // Draw the box
            _scene.Console.FillBox(topLeft, bottomRight, DefaultTextBox.BackgroundColor);

            // Draw the header.
            if (HeaderText != "") {
                contentOffset += HeaderHeight;
                _scene.Console.FillBox(topLeft, new Point(X + Width, Y + HeaderHeight - 1), DefaultTextBox.HeaderBackgroundColor);
                _scene.Console.Write(Y + HeaderHeight / 2, X + 1, HeaderText, DefaultTextBox.HeaderTextColor, null);
            }

            // Draw the content.
            var cnt = 0;
            foreach (ColoredString line in _formattedText) {
                _scene.Console.Write(Y + contentOffset + (cnt++), X + 1, line);
            }
        }
    }
}
