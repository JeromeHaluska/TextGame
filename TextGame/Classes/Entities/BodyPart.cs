namespace Game.Entities
{
    using Items;

    public class BodyPart
    {
        public BodyPart(string name, float hitChanceMultiplier, float damageMultiplier)
        {
            HitChanceMultiplier = hitChanceMultiplier;
            DamageMultiplier = damageMultiplier;
        }

        /// <summary>
        /// Gets or sets the item that is equipped on this body part.
        /// </summary>
        public Item EquippedItem { get; set; }

        /// <summary>
        /// Gets the hit chance multiplier thats used when this body part is attacked.
        /// </summary>
        public float HitChanceMultiplier { get; private set; }

        /// <summary>
        /// Gets the damage multiplier thats used when this body part is attacked.
        /// </summary>
        public float DamageMultiplier { get; private set; }

        /*
        private Entity linkedEntity;

        // Für leichteren Zugriff auf die Variablen.
        private int healthPerLevel;
        public int defaultHealth { get; private set; }

        public BodyPart(Entity linkedEntity, int healthPerLevel,
            Armor equippedArmor = null)
        {
            this.linkedEntity = linkedEntity;
            attributes = new AttributeComponent(
                damage, damageMultiplier,
                armor, armorMultiplier,
                hitChance, hitChanceMultiplier,
                criticalHitChance, criticalHitChanceMultiplier,
                criticalDamage, criticalDamageMultiplier
            );
            this.name = name;
            defaultHealth = health;
            this.health = defaultHealth;
            this.healthPerLevel = healthPerLevel;
            this.equippedArmor = equippedArmor;
            this.isNeededToAttack = isNeededToAttack;
            this.isNeededToLive = isNeededToLive;
        }

        // Fügt dem Körperteil Schaden zu. Gibt die übrigen Leben nach der Schadensberechnung zurück.
        public int Hit(int damage, int attackerLevel)
        {
            float damageReduction = GetDamageReduction(attackerLevel);
            int reducedDamage = (int)(damage * damageReduction);

            return health = Math.Min(Math.Max(health - reducedDamage, 0), defaultHealth);
        }

        // Heilt das Körperteil. Gibt die übrigen Leben nach der Schadensberechnung zurück.
        public int Heal(int value)
        {
            int oldHealth = health;

            health = Math.Max(Math.Min(health + value, defaultHealth), 0);
            return health - oldHealth;
        }

        // Rüstet einen neuen Gegenstand aus und gibt den alten Gegenstand der ausgerüstet war zurück.
        // Falls vorher keine Rüstung angelegt war gibt diese Methode null zurück.
        public Armor SwitchEquippedItem(Armor newArmor)
        {
            Armor oldEquippedArmor = equippedArmor;
            equippedArmor = newArmor;
            return oldEquippedArmor;
        }

        // Skaliert die Leben mit dem übergebenen Level.
        public void ScaleWithLevel()
        {
            defaultHealth = healthPerLevel * linkedEntity.level;
            health = healthPerLevel * linkedEntity.level;
        }

        // Berechnet die Schadensreduktion durch die Rüstung. Das Level des Gegners muss übergeben werden.
        public float GetDamageReduction(int attackerlevel)
        {
            float maxDamageReduction = 0.8f;
            int combinedArmor = 0;

            combinedArmor += linkedEntity.GetTotalArmor();
            combinedArmor += attributes.armor;
            combinedArmor = (int)(combinedArmor * attributes.armorMultiplier);

            float reduction = Math.Min(combinedArmor / (350.0f * attackerlevel), maxDamageReduction);
            return reduction;
        }
        */
    }
}
