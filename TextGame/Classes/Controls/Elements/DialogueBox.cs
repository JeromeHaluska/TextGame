namespace Game.Controls
{
    using System;
    using System.Collections.Generic;
    using OpenTK.Graphics;
    using Scenes;

    public class DialogueBox : IControl
    {
        private Scene _scene;

        private int _x = 0;

        private int _y = 0;

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
        public int X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = Math.Max(value, 0);
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
            }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
                while (_lines.Count < _height) {
                    _lines.Insert(0, string.Empty);
                }
            }
        }

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
            _lines.Add(line);
        }

        /// <summary>
        /// Draws the dialogue box.
        /// Every line gets cut off if its longer then the width of this box.
        /// </summary>
        public void Draw()
        {
            var cntStart = _lines.Count - Height;

            for (int cnt = cntStart; cnt < _lines.Count; cnt++) {
                var curLine = _lines[cnt];
                var shortenedLine = curLine.Substring(0, Math.Min(Width, curLine.Length));

                _scene.Console.Write(Y + cnt - cntStart, X, shortenedLine, TextColor, BackgroundColor);
            }
        }
    }
}
