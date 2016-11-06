namespace Game.Items
{
    public enum ItemType
    {
        Other,
        Material,
        Quest,
        Consumeable,
        Weapon,
        Armor
    }

    public enum ItemRarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Artifact,
        Godly
    }

    public class Item
    {
        public string Name;

        public ItemType Type { get; set; }

        public ItemRarity Rarity { get; set; }

        public Item(string name, ItemType type, ItemRarity rarity)
        {

        }
    }
}
