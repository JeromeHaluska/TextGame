namespace Game.Conditions
{
    using Entities;
    using Items;

    public class ItemEquippedCondition : ICondition
    {
        private Entity _linkedEntity;

        private Item _requiredItem;

        public ItemEquippedCondition(Entity linkedEntity, Item requiredItem)
        {
            _linkedEntity = linkedEntity;
            _requiredItem = requiredItem;
        }

        public bool IsMet()
        {
            return _linkedEntity.Body.IsEquipped(_requiredItem);
        }
    }
}
