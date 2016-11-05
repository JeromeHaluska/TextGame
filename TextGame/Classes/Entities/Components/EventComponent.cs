namespace Game.Entities.Components
{
    using System.Collections.Generic;
    using Draw.Utility;

    public class EventComponent
    {
        /// <summary>
        /// Gets fired when the entity deals damage.
        /// </summary>
        /// <param name="source">The entity that made the attack.</param>
        /// <param name="target">The entity that got hit.</param>
        /// <param name="damageDone">The total amount of damage done to the target.</param>
        public delegate List<ColoredString> OnHitHandler(Entity source, Entity target, int damageDone);

        public OnHitHandler OnHit
        {
            get
            {
                return OnHit;
            }
            set
            {
                OnHit = value;
            }
        }

        /// <summary>
        /// Gets fired when the entity takes damage.
        /// </summary>
        /// <param name="source">The entity that made the attack.</param>
        /// <param name="target">The entity that got hit.</param>
        /// <param name="damageDone">The total amount of damage done to the target.</param>
        public delegate List<ColoredString> OnDamageTakenHandler(Entity source, Entity target, int damageDone);

        public OnDamageTakenHandler OnDamageTaken
        {
            get
            {
                return OnDamageTaken;
            }
            set
            {
                OnDamageTaken = value;
            }
        }

        /// <summary>
        /// Gets fired when the entity kills something
        /// </summary>
        /// <param name="source">The killer.</param>
        /// <param name="target">The entity that died.</param>
        public delegate List<ColoredString> OnKillHandler(Entity source, Entity target);

        public OnKillHandler OnKill
        {
            get
            {
                return OnKill;
            }
            set
            {
                OnKill = value;
            }
        }

        /// <summary>
        /// Gets fired if the entity dies.
        /// </summary>
        /// <param name="source">The killer.</param>
        /// <param name="target">The entity that died.</param>
        public delegate List<ColoredString> OnDeathHandler(Entity source, Entity target);

        public OnDeathHandler OnDeath
        {
            get
            {
                return OnDeath;
            }
            set
            {
                OnDeath = value;
            }
        }
    }
}
