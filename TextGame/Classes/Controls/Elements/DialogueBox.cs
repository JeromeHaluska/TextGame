// TODO:
// - Remove Write method and rename WriteSlow to Write, to make the intent of this element clearer and prevent missusing it.
// - Support colored string.

namespace Game.Controls
{
    using System.Collections.Generic;
    using OpenTK.Graphics;
    using Scenes;
    using System.Threading.Tasks;

    public class DialogueBox : IControl
    {
        private Scene _scene;

        private int _delay;

        private int _height = 0;

        private List<string> _lines = new List<string>();
        
        public DialogueBox(Scene scene, int x, int y, int width, int height, Color4 textColor, Color4? backgroundColor = null)
        {
            _scene = scene;
            Height = height;
            Width = width;
            X = x;
            Y = y;
            TextColor = textColor;
            BackgroundColor = backgroundColor;
        }

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

        /// <summary>
        /// Gets or sets the text color.
        /// </summary>
        public Color4 TextColor { get; set; }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        public Color4? BackgroundColor { get; set; }

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

        public void Write(char ch)
        {
            if (_lines.Count != 0 && _lines[_lines.Count - 1].Length < Width) {
                _lines[_lines.Count - 1] += ch;
            } else {
                // If the current char is a whitespace skip it, and use the next char to start a new line.
                // This isn't necessary for the functionality of the DialogueBox, its of cosmetical nature.
                if (ch != ' ') {
                    // Removes the first line if the number of exsisting lines exceeds the height of the DialogueBox.
                    if (_lines.Count == Height) {
                        _lines.RemoveAt(0);
                    }

                    _lines.Add(ch.ToString());
                }
            }
        }

        public async void WriteSlow(string line)
        {
            foreach (char ch in line) {
                await AddLetter(ch);
            }
        }

        private async Task AddLetter(char ch)
        {
            await Task.Delay(Delay);
            Write(ch);
        }

        /// <summary>
        /// Draws the dialogue box.
        /// Every line gets cut off if its longer then the width of this box.
        /// </summary>
        public void Draw()
        {
            for (int cnt = 0; cnt < _lines.Count; cnt++) {
                var curLine = _lines[cnt];

                _scene.Console.Write(Y + cnt, X, curLine, TextColor, BackgroundColor);
            }
        }
    }
}
