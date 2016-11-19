namespace Game.Items
{
    using Draw.Utility;
    using OpenTK.Graphics;

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
        public Item(string name, ItemType type, ItemRarity rarity)
        {
            Name = name;
            Type = type;
            Rarity = rarity;
        }

        public Color4[] ItemRarityColors = new Color4[] {
            new Color4(1, 1, 1, 1),
            new Color4(0.12f, 1, 0, 1),
            new Color4(0, 0.44f, 1, 1),
            new Color4(0.64f, 0.21f, 0.93f, 1),
            new Color4(1, 0.5f, 0, 1),
            new Color4(0.9f, 0.8f, 0.5f, 1)
        };

        public string Name;

        public ItemType Type { get; set; }

        public ItemRarity Rarity { get; set; }

        public ColoredString ToColoredString()
        {
            return new ColoredString(Name, ItemRarityColors[(int)Rarity]);
        }
    }
}
