namespace Game.StatusEffects
{
    using System;
    using System.Collections.Generic;
    using Conditions;
    using Draw.Utility;
    using Entities;

    public class StatusEffectToughSkin : StatusEffect
    {
        private int _flatDamageReduction = 5;

        private ColoredString[] _onDamageTaken(Entity source, Entity target, KeyValuePair<BodyPart, int>[] damagedBodyParts, int damageDone)
        {
            foreach (KeyValuePair<BodyPart, int> damagedBodyPart in damagedBodyParts) {
                // Reduces the damage that each BodyPart took.
                //damagedBodyPart.Key.Heal(Math.Min(damagedBodyPart.Value, _flatDamageReduction)); NOT IMPLEMENTED YET
            }
            return new ColoredString[0];
        }

        public StatusEffectToughSkin() : base(new NoCondition(), new Entity[1] { Game.Player })
        {
            _linkedEntities[0].Events.OnDamageTaken += _onDamageTaken;
        }

        override public void CleanUp()
        {
            _linkedEntities[0].Events.OnDamageTaken -= _onDamageTaken;
        }
    }
}
