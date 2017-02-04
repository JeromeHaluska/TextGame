namespace Game.StatusEffects
{
    using System.Collections.Generic;
    using Conditions;
    using Entities;
    using Draw.Utility;

    public abstract class StatusEffect
    {
        protected List<Entity> _linkedEntities = new List<Entity>();

        public StatusEffect(ICondition condition, Entity[] affectedEntities)
        {
            Condition = condition;
            _linkedEntities.AddRange(affectedEntities);
        }

        public ICondition Condition { get; private set; }

        /// <summary>
        /// This method stores the main functionality of the status effect.
        /// </summary>
        /// <returns>A text that describes the update.</returns>
        public virtual ColoredString[] Update()
        {
            return new ColoredString[0];
        }

        /// <summary>
        /// Removes the status effect from all affected entities.
        /// </summary>
        public virtual void CleanUp()
        {

        }
    }
}
