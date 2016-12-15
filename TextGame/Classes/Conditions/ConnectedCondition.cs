namespace Game.Conditions
{
    public class ConnectedCondition : ICondition
    {
        ICondition[] _conditions;

        bool _allRequired;

        public ConnectedCondition(ICondition[] conditions, bool allRequired = true)
        {
            _conditions = conditions;
            _allRequired = allRequired;
        }

        public bool IsMet()
        {
            bool isMet = true;

            // Check the status of every condition.
            foreach (ICondition condition in _conditions) {
                // If one of the condition is false and every condition is required this method will return false.
                isMet = condition.IsMet() ? isMet : false;

                // If a condition is met and not every condition is required this condition is met.
                if (!_allRequired && isMet) {
                    return true;
                }
            }

            return isMet;
        }
    }
}
