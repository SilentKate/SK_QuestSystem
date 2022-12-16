using System;
using JetBrains.Annotations;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace QuestSystem.Scripts.Runtime.Goals
{
    public class StateMachineGoal : IGoal
    {
        private readonly ReactiveProperty<int> _currentCount = new();
        private readonly ReactiveProperty<Status> _status = new();
        private readonly StateMachine _machinePrefab;
        private StateMachine _stateMachine;

        public StateMachineGoal(
            string id, 
            int targetCount,
            [NotNull] StateMachine machine)
        {
            Id = !string.IsNullOrEmpty(id) ? id : throw new ArgumentNullException(nameof(id));
            TargetCount = targetCount;
            
            _machinePrefab = machine != null ? machine : throw new ArgumentNullException(nameof(machine));
        }

        [UsedImplicitly]
        public void SetCurrentCount(int value)
        {
            _currentCount.Value = value;
        }

        [UsedImplicitly]
        public void SetStatus(Status value)
        {
            if (value == Goals.Status.None)
            {
                throw new GoalStatusException(this, value);
            }
            
            _status.Value = value;
        }
        
        #region IGoal

        public string Id { get; }
        public int TargetCount { get; }
        public IReadOnlyReactiveProperty<int> CurrentCount => _currentCount;
        public IReadOnlyReactiveProperty<Status> Status => _status;
        
        public void Start()
        {
            _stateMachine = Object.Instantiate(_machinePrefab);
        }

        public void Complete()
        {
        }

        public void Abandon()
        {
        }

        #endregion
    }
}