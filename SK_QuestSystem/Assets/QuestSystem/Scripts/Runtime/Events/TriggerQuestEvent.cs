namespace QuestSystem.Scripts.Runtime.Events
{
    public class TriggerQuestEvent<T> : IQuestEvent where T : ITriggerData
    {
        public T Data { get; }
        public TriggerQuestEvent(T data)
        {
            Data = data;
        }
    }
}