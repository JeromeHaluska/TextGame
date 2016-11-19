namespace Draw.Utility
{
    using System.Collections.Generic;
    using Controls;

    /// <summary>
    /// A scene is used to combine <see cref="IControl"/>. You can implement a menu with a scene see <see cref="MainMenuScene"/>.
    /// </summary>
    public abstract class Scene
    {
        /// <summary>
        /// A list of all used controls by the scene.
        /// </summary>
        private List<IControl> _controlList = new List<IControl>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Scene"/> class.
        /// </summary>
        public Scene()
        {
            Console = ExtendedConsoleWindow.Console;
        }

        /// <summary>
        /// Gets the console of the scene that is used for drawing.
        /// </summary>
        protected ExtendedConsoleWindow Console { private set; get; }

        /// <summary>
        /// Draws all added controls to the console.
        /// Here should all drawing of the scene happen.
        /// This function gets called every 10 milliseconds.
        /// </summary>
        public virtual void Draw()
        {
            foreach (IControl control in _controlList) {
                control.Draw();
            }
        }

        /// <summary>
        /// Adds a control to the Scene.
        /// </summary>
        /// <param name="control">A control element.</param>
        protected void Add(IControl control)
        {
            _controlList.Add(control);
        }

        /// <summary>
        /// Removes a specific control from the Scene.
        /// </summary>
        /// <param name="control">A control element.</param>
        protected void Remove(IControl control)
        {
            _controlList.Remove(control);
        }

        protected void ResetControls()
        {
            _controlList.Clear();
        }
    }
}
