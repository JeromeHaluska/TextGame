namespace Game
{
    using System;
    using Entities;
    using Races;

    public static class Game
    {
        public static Race[] Races = new Race[1] {
            new Human()
        };

        public static Entity Player;
        
        public static float MaxDamageReduction = 0.9f;

        public static int DefaultCriticalHitChance = 5;

        public static int DefaultHitChance = 90;

        /// <summary>
        /// Calculates the damage reduction of an entity.
        /// </summary>
        /// <param name="attackerlevel">Level of the attacking <see cref="Entity"/>.</param>
        /// <param name="combinedArmor">Combined armor of the defending <see cref="Entity"/>.</param>
        /// <returns></returns>
        public static float GetDamageReduction(int attackerlevel, int combinedArmor)
        {
            float reduction = Math.Min(combinedArmor / (350.0f * attackerlevel), MaxDamageReduction);
            return reduction;
        }

        public static string GetApplicationPath()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}
