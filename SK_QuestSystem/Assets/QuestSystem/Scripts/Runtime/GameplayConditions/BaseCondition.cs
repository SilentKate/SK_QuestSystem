namespace QuestSystem.Scripts.Runtime.GameplayConditions
{
    public abstract class BaseCondition : ICondition
    {
        public abstract bool Evaluate<T>(T data);
    }
}