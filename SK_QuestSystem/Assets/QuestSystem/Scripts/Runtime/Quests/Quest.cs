using System.Collections.Generic;

namespace QuestSystem.Scripts.Runtime.Quests
{
    public class Quest
    {
        private readonly IList<IGoal> _goals;
        
        public void AddGoal(IGoal goal)
        {
            _goals.Add(goal);
        }
    }
}