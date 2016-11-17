namespace Draw.Controls
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using OpenTK.Graphics;
    using Scenes;
    using Utility;

    public class DialogueBox : IControl
    {
        private ExtendedConsoleWindow _console;

        private List<ColoredString> _writeQueue = new List<ColoredString>();

        private List<ColoredString> _lines = new List<ColoredString>();
        
        public DialogueBox(int x, int y, int width, int height)
        {
            _console = ExtendedConsoleWindow.Console;
            Height = height;
            Width = width;
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets or sets the default text color.
        /// </summary>
        public static Color4 TextColor { get; set; } = Colors.TextColor;

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        public static Color4? BackgroundColor { get; set; }

        /// <summary>
        /// The delay between each letter when using <see cref="WriteSlow(string)"/> in ms. Default is 50ms.
        /// </summary>
        public static int Delay { get; set; } = 50;

        /// <summary>
        /// Gets or sets the x-position.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the y-position.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public int Width { get; set; }

        /* Deprecated
        /// <summary>
        /// Adds a string to the dialogue box and splits it into seperate lines if its longer then <see cref="Width"/>.
        /// </summary>
        /// <param name="line">A short line of text</param>
        public void WriteLine(string line)
        {
            while (line.Length > Width) {
                // Cut off the line if its length is greater then the dialogue box width.
                var shortenedLine = line.Substring(0, Width);

                // Add the shortened line to the dialogue box output.
                _lines.Add(shortenedLine);

                // Get the rest of the line.
                line = line.Substring(Width);
            }

            _lines.Add(line);
        }

        public void WriteLine(char ch) { WriteLine(ch.ToString()); }

        public void Write(string line)
        {
            foreach (char ch in line) {
                Write(ch);
            }
        }
        */

        public async void Write(ColoredString newLine)
        {
            _writeQueue.Add(newLine);

            if (_writeQueue.Count == 1) {
                while (_writeQueue.Count != 0) {
                    var line = _writeQueue[0];

                    foreach (ColoredChar ch in line) {
                        await Task.Delay(Delay);
                        AddLetter(ch);
                    }
                    _writeQueue.RemoveAt(0);

                    // Adds a new line after every write request.
                    _lines.Add(new ColoredString());
                }
            }
        }

        private void AddLetter(ColoredChar colCh)
        {
            if (_lines.Count != 0 && _lines[_lines.Count - 1].Length < Width) {
                _lines[_lines.Count - 1] += colCh;
            } else {
                // If the current char is a whitespace skip it, and use the next char to start a new line.
                // This isn't necessary for the functionality of the DialogueBox, its of cosmetical nature.
                if (colCh.Value != ' ') {
                    // Removes the first line if the number of exsisting lines exceeds the height of the DialogueBox.
                    if (_lines.Count == Height) {
                        _lines.RemoveAt(0);
                    }

                    _lines.Add(colCh);
                }
            }
        }

        /// <summary>
        /// Draws the dialogue box.
        /// Every line gets cut off if its longer then the width of this box.
        /// </summary>
        public void Draw()
        {
            for (int cnt = 0; cnt < _lines.Count; cnt++) {
                var curLine = _lines[cnt];

                _console.Write(Y + cnt, X, curLine);
            }
        }
    }
}
