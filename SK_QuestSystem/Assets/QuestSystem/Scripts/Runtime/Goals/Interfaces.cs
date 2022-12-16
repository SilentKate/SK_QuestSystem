using UniRx;

namespace QuestSystem.Scripts.Runtime.Goals
{
    public interface IGoal
    {
        string Id { get; }
        int TargetCount { get; }
        
        IReadOnlyReactiveProperty<int> CurrentCount { get; }
        IReadOnlyReactiveProperty<Status> Status { get; }

        void Start();
        void Complete();
        void Abandon();
    }

    public enum Status
    {
        None,
        Progressed,
        Succeed,
        Failed,
        Abandoned
    }
}