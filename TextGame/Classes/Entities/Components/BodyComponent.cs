namespace Game.Entities.Components
{
    using System.Collections.Generic;
    using Items;

    /// <summary>
    /// Use this component if you want something to have a body.
    /// </summary>
    public class BodyComponent
    {
        private List<BodyPart> _bodyPartList = new List<BodyPart>();

        public BodyComponent(BodyPart[] bodyParts)
        {
            _bodyPartList.AddRange(bodyParts);
        }

        public BodyPart[] BodyParts
        {
            get { return _bodyPartList.ToArray(); }
        }

        /// <summary>
        /// Checks all equipped items of the body parts and returns true if the passed item is equipped.
        /// </summary>
        /// <param name="item">The item to look for.</param>
        public bool IsEquipped(Item item)
        {
            // Check if any of the body parts has the item equipped.
            foreach (BodyPart bodyPart in BodyParts) {
                if (bodyPart.EquippedItem == item) {
                    return true;
                }
            }

            return false;
        }
    }
}
