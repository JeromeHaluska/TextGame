namespace Game.Controls.Default
{
    using OpenTK.Graphics;

    public static class DefaultButton
    {
        static Color4 TextColor = Colors.TextColor;
        static Color4 BackgroundColor = Colors.SecondaryColor;
        static Color4 HoverTextColor = Colors.Lighten(TextColor);
        static Color4 HoverBackgroundColor = Colors.Lighten(BackgroundColor);
        static Color4 DisabledTextColor = Colors.Darken(TextColor);
        static Color4 DisabledBackgroundColor = Colors.Darken(BackgroundColor);
        static Color4 HighlightTextColor = Colors.Invert(TextColor);
        static Color4 HighlightBackgroundColor = Colors.Invert(BackgroundColor);
    }
}