namespace Game.Utility.Components
{
    using Entities;

    public class EventComponent
    {
        /// <summary>
        /// Gets fired when the entity deals damage.
        /// </summary>
        /// <param name="source">The entity that made the attack.</param>
        /// <param name="target">The entity that got hit.</param>
        /// <param name="damageDone">The total amount of damage done to the target.</param>
        public delegate void OnHitHandler(Entity source, Entity target, int damageDone);
        public event OnHitHandler OnHit;

        /// <summary>
        /// Gets fired when the entity takes damage.
        /// </summary>
        /// <param name="source">The entity that made the attack.</param>
        /// <param name="target">The entity that got hit.</param>
        /// <param name="damageDone">The total amount of damage done to the target.</param>
        public delegate void OnDamageTakenHandler(Entity source, Entity target, int damageDone);
        public event OnDamageTakenHandler OnDamageTaken;

        /// <summary>
        /// Gets fired when the entity kills something
        /// </summary>
        /// <param name="source">The killer.</param>
        /// <param name="target">The entity that died.</param>
        public delegate void OnKillTakenHandler(Entity source, Entity target);
        public event OnKillTakenHandler OnKill;

        /// <summary>
        /// Gets fired if the entity dies.
        /// </summary>
        /// <param name="source">The killer.</param>
        /// <param name="target">The entity that died.</param>
        public delegate void OnDeathTakenHandler(Entity source, Entity target);
        public event OnDeathTakenHandler OnDeath;
    }
}
