namespace Game.Controls.Default
{
    using OpenTK.Graphics;

    public static class DefaultSelection
    {
        static Color4 TextColor = Colors.TextColor;
        static Color4 BackgroundColor = Colors.BackgroundColor;
        static Color4 HoverTextColor = Colors.Lighten(TextColor);
        static Color4 HoverBackgroundColor = Colors.Lighten(BackgroundColor);
        static Color4 HighlightTextColor = Colors.Invert(TextColor);
        static Color4 HighlightBackgroundColor = Colors.Invert(BackgroundColor);
    }
}