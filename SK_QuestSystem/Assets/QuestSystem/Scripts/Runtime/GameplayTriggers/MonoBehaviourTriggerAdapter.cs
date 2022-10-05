using QuestSystem.Scripts.Runtime.Events;
using UnityEngine;

namespace QuestSystem.Scripts.Runtime.GameplayTriggers
{
    public abstract class MonoBehaviourTriggerAdapter<T> : MonoBehaviour,
        ITriggerAdapter<T> where T : ITriggerData
    {
        public void Invoke(T data)
        {
            var questEvent = new TriggerQuestEvent<T>(data);
            QuestSystem.Instance.QuestEventChannel.FireEvent(questEvent);
        }

        public void Invoke()
        {
            var data = GetData();
            Invoke(data);
        }

        public abstract T GetData();
    }
}