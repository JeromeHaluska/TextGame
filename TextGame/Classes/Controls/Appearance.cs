// TODO:
// - Remove the Appearance struct and provide a better solution.

namespace Game.Controls
{
    using OpenTK.Graphics;

    /// <summary>
    /// Can be used to combine different colors into a theme that can be reused.
    /// </summary>
    public struct Appearance
    {
        public Color4 TextColor;
        public Color4 BackgroundColor;
        public Color4 HoverTextColor;
        public Color4 HoverBackgroundColor;
        public Color4 DisabledTextColor;
        public Color4 DisabledBackgroundColor;
        public Color4 HighlightTextColor;
        public Color4 HighlightBackgroundColor;

        /// <summary>
        /// The default constructor.
        /// </summary>
        public Appearance(
            Color4 textColor,
            Color4 backgroundColor,
            Color4? hoverTextColor = null,
            Color4? hoverBackgroundColor = null,
            Color4? disabledTextColor = null,
            Color4? disabledBackgroundColor = null,
            Color4? highlightTextColor = null,
            Color4? highlightBackgroundColor = null)
        {
            TextColor = textColor;
            BackgroundColor = backgroundColor;

            HoverTextColor = hoverTextColor == null ? Colors.Lighten(textColor) : (Color4)hoverTextColor;
            HoverBackgroundColor = hoverBackgroundColor == null ? Colors.Lighten(backgroundColor) : (Color4)hoverBackgroundColor;

            DisabledTextColor = disabledTextColor == null ? Colors.Darken(textColor) : (Color4)disabledTextColor;
            DisabledBackgroundColor = disabledBackgroundColor == null ? Colors.Darken(backgroundColor) : (Color4)disabledBackgroundColor;

            HighlightTextColor = highlightTextColor == null ? Colors.Invert(textColor) : (Color4)highlightTextColor;
            HighlightBackgroundColor = highlightBackgroundColor == null ? Colors.Invert(backgroundColor) : (Color4)highlightBackgroundColor;
        }

        /// <summary>
        /// The constructor generates Colors based on the 2 passed primary Colors.
        /// </summary>
        public Appearance(Color4 textColor, Color4 backgroundColor)
        {
            TextColor = textColor;
            BackgroundColor = backgroundColor;

            HoverTextColor = Colors.Lighten(textColor);
            HoverBackgroundColor = Colors.Lighten(backgroundColor);

            DisabledTextColor = Colors.Darken(textColor);
            DisabledBackgroundColor = Colors.Darken(backgroundColor);

            HighlightTextColor = Colors.Invert(textColor);
            HighlightBackgroundColor = Colors.Invert(backgroundColor);
        }
    }
}
