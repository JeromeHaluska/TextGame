namespace Game
{
    using System.Linq;
    using OpenTK.Graphics;
    using Scenes;
    using SunshineConsole;
    using System.Drawing;
    using System;

    public class ExtendedConsoleWindow : ConsoleWindow
    {
        private bool _closeWindow = false;

        public ExtendedConsoleWindow(int rows, int columns, string windowTitle) : base(rows, columns, windowTitle)
        {
            Closed += (source, args) => {
                CloseWindow = true;
            };
        }

        public Scene ActiveScene { get; set; }

        public int FontWidth
        {
            get
            {
                return 8;
            }
        }

        public int FontHeight
        {
            get
            {
                return 12;
            }
        }

        public bool CloseWindow
        {
            get
            {
                return _closeWindow;
            }

            set
            {
                _closeWindow = value;
            }
        }

        public void Write(int row, int col, string text)
        {
            Write(row, col, text, Color4.White);
        }

        public void Fill(Color4 backgroundColor, Color4? textColor = null)
        {
            FillBox(new Point(0, 0), new Point(Cols - 1, Rows - 1), backgroundColor, textColor);
        }

        public void FillBox(Point topLeft, Point bottomRight, Color4 backgroundColor, Color4? textColor = null)
        {
            // Validate the points.
            topLeft = new Point(Math.Min(Math.Max(topLeft.X, 0), Cols), Math.Min(Math.Max(topLeft.Y, 0), Rows - 1));
            bottomRight = new Point(Math.Min(Math.Max(bottomRight.X, 0), Cols), Math.Min(Math.Max(bottomRight.Y, 0), Rows - 1));

            for (int row = topLeft.Y; row <= bottomRight.Y; row++) {
                for (int col = topLeft.X; col <= bottomRight.X; col++) {
                    chars[row, col] = ' ';
                    colors[row, col] = textColor != null ? (Color4)textColor : colors[row, col];
                    bgcolors[row, col] = backgroundColor;
                }
            }

            first_changed_row = topLeft.Y;
            last_changed_row = bottomRight.Y;
            first_changed_col = topLeft.X;
            last_changed_col = bottomRight.X;
            UpdateGLBuffer();
        }

        /// <summary>
        /// Extends the functionality of the ConsoleWindow.WindowUpdate Method.
        /// Draws all controls that have been added with the Add function.
        /// </summary>
        public new bool WindowUpdate()
        {
            if (!CloseWindow) {
                base.WindowUpdate();
                ActiveScene.Draw();
                return true;
            }

            return false;
        }

        /// <summary>
        /// This method has a nullable background color parameter, that allows you to keep the current background color.
        /// </summary>
        public void Write(int row, int col, string line, Color4 color, Color4? backgroundColor)
        {
            int i = 0;
            foreach (char ch in line) {
                if (InBounds(row, col + i)) {
                    bool changed = false;

                    if (chars[row, col + i] != ch) {
                        chars[row, col + i] = ch;
                        changed = true;
                    }
                    if (colors[row, col + i] != color) {
                        colors[row, col + i] = color;
                        changed = true;
                    }
                    if (backgroundColor != null && bgcolors[row, col + i] != backgroundColor) {
                        bgcolors[row, col + i] = (Color4)backgroundColor;
                        changed = true;
                    }
                    if (changed) {
                        if (row < first_changed_row) {
                            first_changed_row = row;
                        }
                        if (row > last_changed_row) {
                            last_changed_row = row;
                        }
                        if (col + i < first_changed_col) {
                            first_changed_col = col + i;
                        }
                        if (col + i > last_changed_col) {
                            last_changed_col = col + i;
                        }
                    }
                }
                i++;
            }
            UpdateGLBuffer();
        }
    }
}
