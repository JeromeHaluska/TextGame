namespace Game.Entities.Components
{
    /// <summary>
    /// Use this component if you want something to have attributes.
    /// </summary>
    public class AttributeComponent
    {
        public AttributeComponent(
            int damage, float damageMultiplier,
            int armor, float armorMultiplier,
            float hitChance, float hitChanceMultiplier,
            float criticalHitChance, float criticalHitChanceMultiplier,
            int criticalDamage, float criticalDamageMultiplier)
        {
            Damage = damage;
            DamageMultiplier = damageMultiplier;
            Armor = armor;
            ArmorMultiplier = armorMultiplier;
            HitChance = hitChance;
            HitChanceMultiplier = hitChanceMultiplier;
            CriticalHitChance = criticalHitChance;
            CriticalHitChanceMultiplier = criticalHitChanceMultiplier;
            CriticalDamage = criticalDamage;
            CriticalDamageMultiplier = criticalDamageMultiplier;
        }

        public int Damage { get; set; }

        public float DamageMultiplier { get; set; }

        public int Armor { get; set; }

        public float ArmorMultiplier { get; set; }

        public float HitChance { get; set; }

        public float HitChanceMultiplier { get; set; }

        public float CriticalHitChance { get; set; }

        public float CriticalHitChanceMultiplier { get; set; }

        public int CriticalDamage { get; set; }

        public float CriticalDamageMultiplier { get; set; }
    }
}
