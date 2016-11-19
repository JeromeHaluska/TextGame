namespace Game.Entities
{
    class BodyPart
    {
        /*
        private Entity linkedEntity;
        public Armor equippedArmor;

        // Für leichteren Zugriff auf die Variablen.
        private int healthPerLevel;
        public string name;
        public int defaultHealth { get; private set; }
        public int health { get; private set; }
        public bool isNeededToAttack;
        public bool isNeededToLive;

        public BodyPart(Entity linkedEntity, string name, int health, int healthPerLevel,
            Armor equippedArmor = null,
            bool isNeededToAttack = false, bool isNeededToLive = false,
            int damage = 0, float damageMultiplier = 0,
            int armor = 0, float armorMultiplier = 0,
            float hitChance = 0, float hitChanceMultiplier = 0,
            float criticalHitChance = 0, float criticalHitChanceMultiplier = 0,
            int criticalDamage = 0, float criticalDamageMultiplier = 0)
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

        public bool IsDead()
        {
            return health > 0;
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
