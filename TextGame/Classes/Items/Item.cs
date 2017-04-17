namespace Game.Items
{
    using System;
    using System.Linq;
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
        static private List<Item> _items = new List<Item>();

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

        /// <param name="query">A lambda expression that describes what kind of items you want to get returned.</param>
        /// <returns>Returns specific items from the list of all available items.</returns>
        static public IEnumerable<Item> GetItems(Func<Item, bool> query = null)
        {
            // Load items
            if (_items.Count == 0) {
                // Open the every item type file and extract the raw JSON.
                foreach (ItemType itemType in Enum.GetValues(typeof(ItemType))) {
                    TextReader fileReader = File.OpenText(Game.GetApplicationPath() + @"\data\items\" + ItemTypeToString[itemType] + ".json");
                    var rawJson = fileReader.ReadToEnd();

                    // Convert the raw JSON into a dynamic array of item objects for easy access.
                    var serializer = new JsonSerializer();
                    var itemObjectArray = JArray.Parse(rawJson);

                    // Fill the itemList with Item objects.
                    foreach (JObject itemObject in itemObjectArray) {
                        _items.Add(new Item(itemObject));
                    }
                }
            }

            return query != null ? _items.Where(query) : _items;
        }

        private string _name;

        private ItemType _type;

        private ItemRarity _rarity;

        private int _value;

        private int _maxQuantity;

        private int _quantity = 1;

        private ItemEventHandler _event;

        private Item(JObject itemObject)
        {
            _name = itemObject["name"].Value<string>() ?? "Unkown";
            _type = itemObject["type"] != null ? StringToItemType[itemObject["type"].Value<string>()] : ItemType.Other;
            _rarity = itemObject["rarity"] != null ? StringToItemRarity[itemObject["rarity"].Value<string>()] : ItemRarity.Common;
            _value = itemObject["value"] != null ? itemObject["value"].Value<int>() : 0;
            _maxQuantity = itemObject["maxQuantity"] != null ? itemObject["maxQuantity"].Value<int>() : 1;
            _event = itemObject["scriptPath"] != null ? new ItemEventHandler(itemObject["scriptPath"].Value<string>()) : null;
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

        public int Value
        {
            get { return _value; }
            set { _value = value; }
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
