using System;
using System.Collections.Generic;
using System.Reflection;
using QuestSystem.Scripts.Runtime.Events;
using QuestSystem.Scripts.Runtime.Goals;
using QuestSystem.Scripts.Runtime.Quests;
using QuestSystem.Scripts.Runtime.Utilities;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace QuestSystem.Scripts.Runtime
{
    public class QuestSystem
    {
        private static QuestSystem _instance;

        public static QuestSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new QuestSystem();
                    _instance.Setup();
                }

                return _instance;
            }
        }

        static QuestSystem()
        {
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged += OnPlaymodeStateChanged;
#endif
        }

#if UNITY_EDITOR
        private static void OnPlaymodeStateChanged(PlayModeStateChange obj)
        {
            if (obj is not PlayModeStateChange.ExitingPlayMode)
            {
                return;
            }
            
            _instance.Cleanup();
            _instance = null;
        }
#endif
        
        public QuestEventChannel QuestEventChannel { get; private set; }

        private QuestSystem()
        {
        }
        
        private void Setup()
        {
            var goalFactoryTypes = CollectGoalFactoryTypes();
            var goalFactories = CreateGoalFactories(goalFactoryTypes);

            var questFactory = new QuestFactory(goalFactories);
            QuestEventChannel = new QuestEventChannel();
        }
        
        private void Cleanup()
        {
            QuestEventChannel = null;
        }

        private IReadOnlyDictionary<Type, IGoalFactory> CreateGoalFactories(IList<Type> goalFactoryTypes)
        {
            var result = new Dictionary<Type, IGoalFactory>();

            foreach (var factoryType in goalFactoryTypes)
            {
                var factory = Activator.CreateInstance(factoryType);
                result[factoryType] = factory as IGoalFactory;
            }
            
            return result;
        }

        private IList<Type> CollectGoalFactoryTypes()
        {
            var result = new List<Type>();
            var factoryTypes = TypeExtensions.GetAllDerivedTypes<IGoalFactory>();
            foreach (var type in factoryTypes)
            {
                if (type.IsAbstract) continue;
                var attribute = type.GetCustomAttribute<GoalFactoryAttribute>();
                if (attribute == null)
                {
                    throw new InvalidOperationException($"No {typeof(GoalFactoryAttribute)} for {type.Name}");
                }

                if (attribute.FactoryType == null)
                {
                    throw new InvalidOperationException(nameof(attribute.FactoryType));
                }
                
                result.Add(type);
            }
            return result;
        }
    }
}