namespace QuestSystem.Scripts.Runtime.Goals
{
    public class Goal<T> : IGoal, ITriggerHandler<T> where T : ITriggerData
    {
        public bool IsCompleted { get; private set; }
        
        private readonly ITrigger _trigger;
        private readonly ICondition _condition;

        public Goal(
            ITrigger trigger,
            ICondition condition)
        {
            _trigger = trigger;
            _condition = condition;
        }

        private void Complete()
        {
            IsCompleted = true;
            _trigger.UnregisterHandler(this);
        }
        
        public void Start()
        {
            _trigger.RegisterHandler(this);
        }
        
        public void Invoke(T data)
        {
            var isOk = _condition.Evaluate(data);
            if (isOk)
            {
                Complete();
            }
        }
    }
}