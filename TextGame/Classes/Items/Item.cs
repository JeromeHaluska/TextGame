namespace Game.Items
{
    using System.IO;
    using System.Collections.Generic;
    using Draw.Utility;
    using OpenTK.Graphics;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

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
        static private Dictionary<ItemType, Item[]> _items = new Dictionary<ItemType, Item[]>();

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

        static public Dictionary<ItemType, string> ItemTypeToString = new Dictionary<ItemType, string> {
            { ItemType.Other, "other" },
            { ItemType.Material, "material" },
            { ItemType.Quest, "quest" },
            { ItemType.Consumeable, "consumeable" },
            { ItemType.Weapon, "weapon" },
            { ItemType.Armor, "armor" }
        };

        static public Dictionary<string, ItemRarity> StringToItemRarity = new Dictionary<string, ItemRarity> {
            { "common", ItemRarity.Common },
            { "uncommon", ItemRarity.Uncommon },
            { "rare", ItemRarity.Rare },
            { "epic", ItemRarity.Epic },
            { "artifact", ItemRarity.Artifact },
            { "godly", ItemRarity.Godly }
        };

        static public Item[] GetItems(ItemType itemType)
        {
            if (_items.ContainsKey(itemType)) {
                return _items[itemType];
            }

            var itemList = new List<Item>();

            // Open the item type file and extract the raw JSON.
            TextReader fileReader = File.OpenText(Game.GetApplicationPath() + @"\data\items\" + ItemTypeToString[itemType] + ".json");
            var rawJson = fileReader.ReadToEnd();

            // Convert the raw JSON into a dynamic array of item objects for easy access.
            var serializer = new JsonSerializer();
            dynamic itemDataArray = JArray.Parse(rawJson);

            // Fill the itemList with Item objects.
            foreach (dynamic itemData in itemDataArray) {
                itemList.Add(new Item(itemData));
            }
            
            _items.Add(itemType, itemList.ToArray());

            return _items[itemType];
        }

        private string _name;

        private ItemType _type;

        private ItemRarity _rarity;

        private int _maxQuantity;

        private int _quantity = 1;

        private ItemEventHandler _event;

        private Item(dynamic itemData)
        {
            _name = itemData.name;
            _type = StringToItemType[itemData.type.Value];
            _rarity = StringToItemRarity[itemData.rarity.Value];
            _maxQuantity = itemData.maxQuantity;
            _event = new ItemEventHandler(itemData.scriptPath.Value);
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ItemType Type
        {
            get { return _type; }
        }

        public ItemRarity Rarity
        {
            get { return _rarity; }
            set { _rarity = value; }
        }

        public ItemEventHandler Event
        {
            get { return _event; }
        }

        public ColoredString ToColoredString()
        {
            return new ColoredString(Name, ItemRarityColors[(int)Rarity]);
        }
    }
}
