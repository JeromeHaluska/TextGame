

namespace Game.Entities
{
    using Utility.Components;

    public abstract class Entity
    {
        public Entity(
            string name, 
            int damage, float damageMultiplier,
            int armor, float armorMultiplier,
            float hitChance, float hitChanceMultiplier,
            float criticalHitChance, float criticalHitChanceMultiplier,
            int criticalDamage, float criticalDamageMultiplier)
        {
            Attributes = new AttributeComponent(
                damage, damageMultiplier,
                armor, armorMultiplier,
                hitChance, hitChanceMultiplier,
                criticalHitChance, criticalHitChanceMultiplier,
                criticalDamage, criticalDamageMultiplier
            );

            Body = new BodyComponent();
        }

        public BodyComponent Body { get; private set; }

        public AttributeComponent Attributes { get; private set; }

        public EventComponent Events { get; private set; } = new EventComponent();
    }
}
