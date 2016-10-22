namespace Game
{
    using OpenTK.Graphics;

    /// <summary>
    /// A collection of the most used colors
    /// </summary>
    public class Colors
    {
        /// <summary>
        /// Gets or sets the primary color of the game.
        /// </summary>
        public static Color4 PrimaryColor { get; set; } = new Color4(143, 86, 59, 255);

        /// <summary>
        /// Gets or sets the secondary color of the game.
        /// </summary>
        public static Color4 SecondaryColor { get; set; } = new Color4(102, 57, 49, 255);

        /// <summary>
        /// Gets or sets the teritary color of the game.
        /// </summary>
        public static Color4 TeritaryColor { get; set; } = new Color4(34, 32, 52, 255);

        /// <summary>
        /// Gets or sets the primary text color of the game.
        /// </summary>
        public static Color4 TextColor { get; set; } = new Color4(200, 200, 200, 255);

        /// <summary>
        /// Gets or sets the primary text header color of the game.
        /// </summary>
        public static Color4 HeaderColor { get; set; } = new Color4(255, 255, 255, 255);

        /// <summary>
        /// Gets or sets the background color a box on the screen.
        /// </summary>
        public static Color4 BoxColor { get; set; } = SecondaryColor;

        /// <summary>
        /// Gets or sets the background color of the game.
        /// </summary>
        public static Color4 BackgroundColor { get; set; } = TeritaryColor;

        public static Color4 DarkBackgroundColor { get; set; } = Darken(TeritaryColor);

        public static Color4 Darken(Color4 color)
        {
            return new Color4(color.R * 0.5f, color.G * 0.5f, color.B * 0.5f, color.A);
        }

        public static Color4 Lighten(Color4 color)
        {
            return new Color4(color.R * 1.3f, color.G * 1.3f, color.B * 1.3f, color.A);
        }

        public static Color4 Invert(Color4 color)
        {
            return new Color4(-(color.R - 1f), -(color.G - 1f), -(color.B - 1f), color.A);
        }
    }
}
