namespace Game.Items
{
    public interface IBuildItems
    {
        /// <summary>
        /// The type of the created Item.
        /// </summary>
        ItemType OutputType { get; set; }

        /// <summary>
        /// Creates a custom item and returns it.
        /// </summary>
        /// <returns>A new item.</returns>
        Item Create();
    }
}
