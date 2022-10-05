using System;
using QuestSystem.Scripts.Runtime.GameplayTriggers;

namespace QuestSystem.Scripts.Runtime.DataBase
{
    public class GoalDataSource : IGoalDataSource
    {
        public string Id
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Title
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Description
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int TargetCount
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ITrigger Trigger
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public Type GetTriggerType()
        {
            throw new NotImplementedException();
        }
    }
}