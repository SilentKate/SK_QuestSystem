using System;
using System.Collections.Generic;
#if UNITY_EDITOR
#endif

namespace QuestSystem.Scripts.Runtime.Events
{
    public class QuestEventChannel
    {
        private readonly Dictionary<Type, HashSet<object>> _listeners = new();
        
        public void FireEvent(object data)
        {
            var type = data.GetType();
            if (!_listeners.TryGetValue(type, out var typedListeners)) 
                return;
            
            foreach (var typedListener in typedListeners)
            {
                var listener = (IQuestEventListener)typedListener;
                listener.Invoke(data);
            }
        }
        
        public void FireEvent<T>(T data)
            where T : IQuestEvent
        {
            var type = typeof(T);
            if (!_listeners.TryGetValue(type, out var typedListeners)) 
                return;
            
            foreach (var typedListener in typedListeners)
            {
                var listener = (IQuestEventListener<T>)typedListener;
                listener.Invoke(data);
            }
        }
        
        public void RegisterListener<T>(IQuestEventListener<T> listener)
            where T: IQuestEvent
        {
            var type = typeof(T);
            if (!_listeners.TryGetValue(type, out var typedListeners))
            {
                typedListeners = new HashSet<object>();
                _listeners[type] = typedListeners;
            }
            typedListeners.Add(listener);
        }
        
        public void UnregisterListener<T>(IQuestEventListener<T> listener)
            where T: IQuestEvent
        {
            var type = typeof(T);
            if (_listeners.TryGetValue(type, out var typedListeners))
            {
                typedListeners.Remove(listener);
            }
        }
    }
}
