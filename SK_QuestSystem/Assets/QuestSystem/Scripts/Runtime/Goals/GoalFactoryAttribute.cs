using System;

namespace QuestSystem.Scripts.Runtime.Goals
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GoalFactoryAttribute : Attribute
    {
        public Type FactoryType { get; }

        public GoalFactoryAttribute(Type factoryType)
        {
            FactoryType = factoryType;
        }
    }
}