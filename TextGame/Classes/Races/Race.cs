namespace Game.Races
{
    using Entities;
    using Traits;

    public abstract class Race
    {
        public string Name { get; protected set; }

        public BodyPart[] BodyParts { get; protected set; }

        public Trait[] Traits { get; protected set; }
    }
}
