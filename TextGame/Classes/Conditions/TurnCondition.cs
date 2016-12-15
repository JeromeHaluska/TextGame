namespace Game.Conditions
{
    public class TurnCondition : ICondition
    {
        private int _initialDuration;

        private int _duration;

        /// <summary>
        /// gsdg
        /// </summary>
        /// <param name="duration">The ammount of ticks this condition is met.</param>
        public TurnCondition(int duration)
        {
            _initialDuration = duration;
            _duration = _initialDuration;
        }

        public bool IsMet()
        {
            return _duration > 0;
        }

        /// <summary>
        /// Counts down the duration of the condition.
        /// </summary>
        /// <returns>True if the condition is met and false if it's not.</returns>
        public bool Tick()
        {
            bool isMet = IsMet();
            _duration -= 1;
            return isMet;
        }

        /// <summary>
        /// Sets the current duration to the initial value.
        /// </summary>
        public void RefreshDuration()
        {
            _duration = _initialDuration;
        }
    }
}
