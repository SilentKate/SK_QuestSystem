using System;
using System.Collections.Generic;
using QuestSystem.Scripts.Runtime.DataBase;

namespace QuestSystem.Scripts.Runtime.Quests
{
    public class QuestFactory
    {
        private readonly IReadOnlyDictionary<Type, IGoalFactory> _factoriesByTriggerType;

        public QuestFactory(
            IReadOnlyDictionary<Type, IGoalFactory> goalFactories)
        {
            _factoriesByTriggerType = goalFactories;
        }

        public void Create()
        {
            var quest = new Quest();
            var goalDataSource = new GoalDataSource();
            var triggerType = goalDataSource.GetTriggerType();
            if (!_factoriesByTriggerType.TryGetValue(triggerType, out var factory))
            {
                
            }
            else
            {
                var goal = factory.Create(goalDataSource);
                quest.AddGoal(goal);
            }
            
        }
    }
}