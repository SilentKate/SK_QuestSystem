#nullable enable

using System;
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
        void Abandon();
    }

    public readonly struct GoalId
    {
        public readonly int Value;

        public GoalId(int value)
        {
            Value = value;
        }

        public bool Equals(GoalId other) => Value == other.Value;
        public override bool Equals(object? obj) => obj is GoalId other && Equals(other);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static Boolean operator ==(GoalId left, GoalId right) => left.Value == right.Value;
        public static Boolean operator !=(GoalId left, GoalId right) => left.Value != right.Value;
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