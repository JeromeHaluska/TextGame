namespace Game.Traits
{
    using StatusEffects;

    public class Trait
    {
        private StatusEffect _statusEffect;

        public string Name { get; protected set; }
        
        public string Description { get; protected set; }
    }
}
