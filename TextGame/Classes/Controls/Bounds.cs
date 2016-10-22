namespace Game.Controls
{
    using System.Drawing;

    /// <summary>
    /// Used to check if points are inside of an rectangle.
    /// </summary>
    public class Bounds
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bounds" /> class.
        /// </summary>
        /// <param name="topLeft">The point at the top left of the bounds.</param>
        /// <param name="bottomRight">The point at the bottom right of the bounds.</param>
        public Bounds(Point topLeft, Point bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        /// <summary>
        /// Gets the Point at the top left of the bounds.
        /// </summary>
        public Point TopLeft { get; }

        /// <summary>
        /// Gets the Point at the bottom right of the bounds.
        /// </summary>
        public Point BottomRight { get; }

        /// <summary>
        /// Checks if the point p is inside the bounds.
        /// </summary>
        /// <param name="p">Checks if this point is inside the bounds.</param>
        /// <returns>Returns a boolean that is true if the bounds contains the point p.</returns>
        public bool Contains(Point p)
        {
            return p.X > TopLeft.X && p.Y > TopLeft.Y && p.X < BottomRight.X && p.Y < BottomRight.Y ? true : false;
        }
    }
}
