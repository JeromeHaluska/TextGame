namespace Game.Controls
{
    using System;
    using System.Collections.Generic;
    using OpenTK.Graphics;
    using Scenes;

    public class DialogueBox : IControl
    {
        private Scene _scene;

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

        /// <summary>
        /// Adds a line to the dialogue box and pushes older lines to the top.
        /// </summary>
        /// <param name="line">A short line of text</param>
        public void Write(string line)
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
