namespace Draw.Controls.Default
{
    using OpenTK.Graphics;

    public static class DefaultButton
    {
        public static Color4 TextColor { get; set; } = Colors.TextColor;
        public static Color4 BackgroundColor { get; set; } = Colors.SecondaryColor;
        public static Color4 HoverTextColor { get; set; } = Colors.Lighten(TextColor);
        public static Color4 HoverBackgroundColor { get; set; } = Colors.Lighten(BackgroundColor);
        public static Color4 DisabledTextColor { get; set; } = Colors.Darken(TextColor);
        public static Color4 DisabledBackgroundColor { get; set; } = Colors.Darken(BackgroundColor);
        public static Color4 HighlightTextColor { get; set; } = Colors.Invert(TextColor);
        public static Color4 HighlightBackgroundColor { get; set; } = Colors.Invert(BackgroundColor);
    }
}