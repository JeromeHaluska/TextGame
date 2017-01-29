namespace Game.Entities.Components
{
    using System.Collections.Generic;
    using Draw.Utility;

    public class EntityEventComponent
    {
        /// <summary>
        /// Gets fired when the entity deals damage.
        /// </summary>
        /// <param name="source">The entity that made the attack.</param>
        /// <param name="target">The entity that got hit.</param>
        /// <param name="damagedBodyParts">Contains all body parts that took damage and the amount of damage taken.</param>
        /// <param name="damageDone">The total amount of damage done to the target.</param>
        public delegate ColoredString[] OnHitHandler(Entity source, Entity target, KeyValuePair<BodyPart, int>[] damagedBodyParts, int damageDone);

        private OnHitHandler _onHit;

        public OnHitHandler OnHit
        {
            get { return _onHit; }
            set { _onHit = value; }
        }

        /// <summary>
        /// Gets fired when the entity takes damage.
        /// </summary>
        /// <param name="source">The entity that made the attack.</param>
        /// <param name="target">The entity that got hit.</param>
        /// <param name="target">The entity that got hit.</param>
        /// <param name="damagedBodyParts">Contains all body parts that took damage and the amount of damage taken.</param>
        public delegate ColoredString[] OnDamageTakenHandler(Entity source, Entity target, KeyValuePair<BodyPart, int>[] damagedBodyParts, int damageDone);

        private OnDamageTakenHandler _onDamageTaken;

        public OnDamageTakenHandler OnDamageTaken
        {
            get { return _onDamageTaken; }
            set { _onDamageTaken = value; }
        }

        /// <summary>
        /// Gets fired when the entity kills something
        /// </summary>
        /// <param name="source">The killer.</param>
        /// <param name="target">The entity that died.</param>
        public delegate ColoredString[] OnKillHandler(Entity source, Entity target);

        private OnKillHandler _onKill;

        public OnKillHandler OnKill
        {
            get { return _onKill; }
            set { _onKill = value; }
        }

        /// <summary>
        /// Gets fired if the entity dies.
        /// </summary>
        /// <param name="source">The killer.</param>
        /// <param name="target">The entity that died.</param>
        public delegate ColoredString[] OnDeathHandler(Entity source, Entity target);

        private OnDeathHandler _onDeath;

        public OnDeathHandler OnDeath
        {
            get { return _onDeath; }
            set { _onDeath = value; }
        }
    }
}
