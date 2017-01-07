namespace Game.StatusEffects
{
    using System.Collections.Generic;
    using Conditions;
    using Entities;

    public abstract class StatusEffect
    {
        private List<Entity> _linkedEntities = new List<Entity>();

        public StatusEffect(ICondition condition)
        {
            Condition = condition;
        }

        public ICondition Condition { get; private set; }

        public virtual void Update()
        {

        }
    }
}
