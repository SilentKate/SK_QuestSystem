namespace QuestSystem.Scripts.Runtime.Events
{
    public interface IQuestEventListener<in T> : IQuestEventListener
        where T: IQuestEvent
    {
        void Invoke(T data);
    }
    
    public interface IQuestEventListener
    {
        void Invoke(object data);
    }
}