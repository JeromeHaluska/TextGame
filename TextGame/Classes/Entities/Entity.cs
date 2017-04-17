namespace Game.Entities
{
    using Attributes;
    using Components;

    public enum EntityType
    {
        Humanoid,
        Beast,
        Dragon,
        Elemental,
        Undead,
        Demon
    }

    public abstract class Entity
    {
        public Entity(string name, EntityType type, BodyPart[] bodyParts)
        {
            Type = type;
            Body = new BodyComponent(bodyParts);

            Attributes.LinkModifier(BaseAttributes);
            BaseAttributes.Add.Add(Attribute.HitChance, Game.DefaultHitChance);
            BaseAttributes.Add.Add(Attribute.CriticalHitChance, Game.DefaultCriticalHitChance);
        }

        public BodyComponent Body { get; protected set; }

        public EntityType Type { get; protected set; }

        public AttributeModifier BaseAttributes { get; protected set; } = new AttributeModifier();

        public AttributeComponent Attributes { get; protected set; } = new AttributeComponent();

        public EntityEventComponent Events { get; protected set; } = new EntityEventComponent();
    }
}
