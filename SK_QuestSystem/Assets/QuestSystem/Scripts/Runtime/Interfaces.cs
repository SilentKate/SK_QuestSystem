using System;

namespace QuestSystem.Scripts.Runtime
{
    public interface IGoalDataSource
    {
        string Id { get; }
        string Title { get; }
        string Description { get; }
        int TargetCount { get; }
        ITrigger Trigger { get; }
        Type GetTriggerType();
    }
    
    public interface IGoal
    {
        bool IsCompleted { get; }
        void Start();
    }
    
    public interface IGoalFactory
    {
        IGoal Create(IGoalDataSource dataSource);
    }
    
    public interface ITriggerData
    {
    }
    
    public interface ITriggerHandler<in T> where T : ITriggerData
    {
        void Invoke(T data);
    }

    public interface ITrigger
    {
        void RegisterHandler<T>(ITriggerHandler<T> handler) where T : ITriggerData;
        void UnregisterHandler<T>(ITriggerHandler<T> handler) where T : ITriggerData;
    }
    
    public interface ITriggerAdapter<in T> where T : ITriggerData
    {
        void Invoke(T data);
    }
    
    public interface ICondition
    {
        bool Evaluate<T>(T data);
    }
}