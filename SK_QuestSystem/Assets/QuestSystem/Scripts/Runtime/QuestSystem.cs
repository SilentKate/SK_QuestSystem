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
        
        private QuestSystem()
        {
        }
        
        private void Setup()
        {
        }
        
        private void Cleanup()
        {
        }
    }
}