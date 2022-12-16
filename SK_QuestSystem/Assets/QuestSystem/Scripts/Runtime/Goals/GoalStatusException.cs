using System;

namespace QuestSystem.Scripts.Runtime.Goals
{
    public class GoalStatusException : Exception
    {
        private const string MessageFormat = "Tried set status {0} to goal {1} with status {2}";

        private static string GetMessage(IGoal goal, Status status)
        {
            return string.Format(MessageFormat, goal.Status.Value, goal.Id, status);
        }
        
        public GoalStatusException(IGoal goal, Status status) : base(GetMessage(goal, status))
        {
        }
    }
}