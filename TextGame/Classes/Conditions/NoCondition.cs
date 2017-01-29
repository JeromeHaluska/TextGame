namespace Game.Conditions
{
    public class NoCondition : ICondition
    {
        public bool IsMet()
        {
            return true;
        }
    }
}