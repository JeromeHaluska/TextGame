

namespace Game.Entities
{
    using Attributes;
    using Components;

    public abstract class Entity
    {
        public Entity(string name)
        {
            Body = new BodyComponent();

            Attributes.LinkModifier(BaseAttributes);
            BaseAttributes.Add.Add(Attribute.HitChance, 90);
            BaseAttributes.Add.Add(Attribute.CriticalHitChance, 5);
        }

        public BodyComponent Body { get; protected set; }

        public AttributeModifier BaseAttributes { get; protected set; } = new AttributeModifier();

        public AttributeComponent Attributes { get; protected set; } = new AttributeComponent();

        public EntityEventComponent Events { get; protected set; } = new EntityEventComponent();
    }
}
