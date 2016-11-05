namespace Game.Entities
{
    public class Player : Entity
    {
        public Player(
            string name,
            int damage, float damageMultiplier,
            int armor, float armorMultiplier,
            float hitChance, float hitChanceMultiplier,
            float criticalHitChance, float criticalHitChanceMultiplier,
            int criticalDamage, float criticalDamageMultiplier)
            : base(
            name,
            damage, damageMultiplier,
            armor, armorMultiplier,
            hitChance, hitChanceMultiplier,
            criticalHitChance, criticalHitChanceMultiplier,
            criticalDamage, criticalDamageMultiplier)
        {
        }
    }
}
