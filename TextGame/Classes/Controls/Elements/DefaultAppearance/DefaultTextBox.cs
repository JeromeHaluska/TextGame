namespace Game.Controls.Default
{
    using OpenTK.Graphics;

    public static class DefaultTextBox
    {
        public static Color4 TextColor { get; set; } = Colors.TextColor;
        public static Color4 BackgroundColor { get; set; } = Colors.Darken(Colors.BackgroundColor);
        public static Color4 HeaderTextColor { get; set; } = Colors.HeaderColor;
        public static Color4 HeaderBackgroundColor { get; set; } = Colors.Darken(BackgroundColor);
    }
}