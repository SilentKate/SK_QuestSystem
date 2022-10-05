using System;
using System.Collections.Generic;

namespace QuestSystem.Scripts.Runtime.GameplayTriggers
{
    public class BaseTrigger : ITrigger
    {
        private readonly Dictionary<Type, HashSet<object>> _handlers = new();

        public void Handle<T>(T data) where T : ITriggerData
        {
            var type = typeof(T);
            if (!_handlers.TryGetValue(type, out var typedListeners))
                return;

            foreach (var typedListener in typedListeners)
            {
                var handler = (ITriggerHandler<T>) typedListener;
                handler.Invoke(data);
            }
        }

        public void RegisterHandler<T>(ITriggerHandler<T> handler) where T : ITriggerData
        {
            var type = typeof(T);
            if (!_handlers.TryGetValue(type, out var typedHandlers))
            {
                typedHandlers = new HashSet<object>();
                _handlers[type] = typedHandlers;
            }

            typedHandlers.Add(handler);
        }

        public void UnregisterHandler<T>(ITriggerHandler<T> handler) where T : ITriggerData
        {
            var type = typeof(T);
            if (_handlers.TryGetValue(type, out var typedListeners))
            {
                typedListeners.Remove(handler);
            }
        }
    }
}