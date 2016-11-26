namespace Game.Items
{
    using System.Collections.Generic;
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
        static public Color4[] ItemRarityColors = new Color4[] {
            new Color4(1, 1, 1, 1),
            new Color4(0.12f, 1, 0, 1),
            new Color4(0, 0.44f, 1, 1),
            new Color4(0.64f, 0.21f, 0.93f, 1),
            new Color4(1, 0.5f, 0, 1),
            new Color4(0.9f, 0.8f, 0.5f, 1)
        };

        static public Dictionary<string, ItemType> StringToItemType = new Dictionary<string, ItemType> {
            { "other", ItemType.Other },
            { "material", ItemType.Material },
            { "quest", ItemType.Quest },
            { "consumeable", ItemType.Consumeable },
            { "weapon", ItemType.Weapon },
            { "armor", ItemType.Armor }
        };

        static public Dictionary<string, ItemRarity> StringToItemRarity = new Dictionary<string, ItemRarity> {
            { "common", ItemRarity.Common },
            { "uncommon", ItemRarity.Uncommon },
            { "rare", ItemRarity.Rare },
            { "epic", ItemRarity.Epic },
            { "artifact", ItemRarity.Artifact },
            { "godly", ItemRarity.Godly }
        };

        public Item(string name, ItemType type, ItemRarity rarity)
        {
            Name = name;
            Type = type;
            Rarity = rarity;
        }

        public string Name;

        public ItemType Type { get; set; }

        public ItemRarity Rarity { get; set; }

        public ColoredString ToColoredString()
        {
            return new ColoredString(Name, ItemRarityColors[(int)Rarity]);
        }
    }
}
