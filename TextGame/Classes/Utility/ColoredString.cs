namespace Draw.Utility
{
    using System.Collections;
    using System.Collections.Generic;
    using OpenTK.Graphics;

    public class ColoredString : IEnumerable<ColoredChar>
    {
        private List<ColoredChar> _colChars = new List<ColoredChar>();

        public ColoredString(string line, Color4? textColor = null, Color4? backgroundColor = null)
        {
            // TODO: Check if creating a list (or array) and use at the and List.AddRange at the end is faster.
            foreach(char ch in line) {
                _colChars.Add(new ColoredChar(ch, textColor, backgroundColor));
            }
        }

        public ColoredString(ColoredChar colChar)
        {
            _colChars.Add(colChar);
        }

        public ColoredString() {}

        /// <summary>
        /// Returns the length of the colored string.
        /// </summary>
        public int Length { get { return _colChars.Count; } }

        /// <return>
        /// Returns a part of this colored string.
        /// </return>
        public ColoredString Substring(int startIndex, int length = 0)
        {
            var shortenedColString = new ColoredString();
            var stopIndex = length > 0 ? length : _colChars.Count;

            for (int cnt = startIndex; cnt < stopIndex; cnt++) {
                shortenedColString += _colChars[cnt];
            }

            return shortenedColString;
        }

        public static ColoredString[] ToArray(string[] lines, Color4? textColor = null, Color4? backgroundColor = null)
        {
            var outputArray = new ColoredString[lines.Length];

            for (int cnt = 0; cnt < outputArray.Length; cnt++) {
                outputArray[cnt] = new ColoredString(lines[cnt], textColor, backgroundColor);
            }

            return outputArray;
        }

        public void Insert(int index, ColoredString colString)
        {
            _colChars.InsertRange(index, colString._colChars);
        }

        public void AddGradient(Color4 c1, Color4 c2, bool changeText = false, bool changeBackground = false)
        {
            double numChars = _colChars.Count;

            for (int cnt = 1;  cnt <= _colChars.Count; cnt++) {
                ColoredChar oldColCh = _colChars[cnt - 1];

                // Generate the gradient at the current index.
                double amount = 1 - cnt / numChars;
                float r = (float)((c1.R * amount) + c2.R * (1 - amount));
                float g = (float)((c1.G * amount) + c2.G * (1 - amount));
                float b = (float)((c1.B * amount) + c2.B * (1 - amount));
                var newColor = new Color4(r, g, b, 1);

                // Apply the new color.
                _colChars[cnt - 1] = new ColoredChar(
                    oldColCh.Value,
                    changeText ? newColor : oldColCh.TextColor,
                    changeBackground ? newColor : oldColCh.BackgroundColor
                );
            }
        }

        public static implicit operator ColoredString(ColoredChar a)
        {
            return new ColoredString(a);
        }

        public static ColoredString operator +(ColoredString a, ColoredString b)
        {
            a._colChars.AddRange(b._colChars);
            return a;
        }

        public static ColoredString operator +(ColoredString a, ColoredChar b)
        {
            a._colChars.Add(b);
            return a;
        }

        public ColoredChar this[int i]
        {
            get { return _colChars[i]; }
            set { _colChars[i] = value; }
        }

        public IEnumerator<ColoredChar> GetEnumerator() { return _colChars.GetEnumerator(); }
        
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }

    /// <summary>
    /// A colored string contains one or more colored char. Its the base of the colored string.
    /// </summary>
    public struct ColoredChar
    {
        public char Value;

        public Color4? TextColor;

        public Color4? BackgroundColor;

        public ColoredChar(char value, Color4? textColor = null, Color4? backgroundColor = null)
        {
            Value = value;
            TextColor = textColor;
            BackgroundColor = backgroundColor;
        }
    }
}
