namespace Game.Attributes
{
    using System.Collections.Generic;

    public enum Attribute
    {
        Health,
        Mana,
        Damage,
        Armor,
        HitChance,
        CriticalHitChance,
        CriticalDamage
    }

    /// <summary>
    /// Is used to modify attributes of a player. Every item status effect or trait can have a modifier.
    /// </summary>
    /// <example>
    /// // Adding a flat amount to the damage attribute.
    /// Add.Add(Attribute.Damage, 50);
    /// </example>
    public class AttributeModifier
    {
        public Dictionary<Attribute, int> Add = new Dictionary<Attribute, int>();

        public Dictionary<Attribute, float> Multiply = new Dictionary<Attribute, float>();
    }
}
