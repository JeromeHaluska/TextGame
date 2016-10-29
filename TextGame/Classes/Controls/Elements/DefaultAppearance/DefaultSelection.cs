namespace Game.Controls.Default
{
    using OpenTK.Graphics;

    public static class DefaultSelection
    {
        public static Color4 TextColor { get; set; } = Colors.TextColor;
        public static Color4 BackgroundColor { get; set; } = Colors.BackgroundColor;
        public static Color4 HoverTextColor { get; set; } = Colors.Lighten(TextColor);
        public static Color4 HoverBackgroundColor { get; set; } = Colors.Lighten(BackgroundColor);
        public static Color4 HighlightTextColor { get; set; } = Colors.Invert(TextColor);
        public static Color4 HighlightBackgroundColor { get; set; } = Colors.Invert(BackgroundColor);
    }
}