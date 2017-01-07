namespace Game.Entities.Components
{
    using System.Collections.Generic;
    using Attributes;

    /// <summary>
    /// Use this component if something derives attributes from many different <see cref="AttributeModifier"/>.
    /// </summary>
    public class AttributeComponent
    {
        private List<AttributeModifier> _linkedModifiers = new List<AttributeModifier>();

        public void LinkModifier(AttributeModifier modifier)
        {
            _linkedModifiers.Add(modifier);
        }

        public void RemoveModifier(AttributeModifier modifier)
        {
            _linkedModifiers.Remove(modifier);
        }

        public int GetTotalAddend(Attribute attribute)
        {
            int totalAddend = 0;

            foreach (AttributeModifier modifier in _linkedModifiers) {
                if (modifier.Add.ContainsKey(attribute)) {
                    totalAddend += modifier.Add[attribute];
                }
            }

            return totalAddend;
        }

        public float GetTotalMultiplier(Attribute attribute)
        {
            float totalMultiplier = 0;

            foreach (AttributeModifier modifier in _linkedModifiers) {
                if (modifier.Multiply.ContainsKey(attribute)) {
                    totalMultiplier += modifier.Multiply[attribute];
                }
            }

            return totalMultiplier;
        }
    }
}
