using JetBrains.Annotations;
using QuestSystem.Scripts.Runtime.GameplayTriggers.Data;
using UnityEngine;

namespace QuestSystem.Scripts.Runtime.GameplayTriggers.Adapter
{
    public class CountAdapter : MonoBehaviourTriggerAdapter<CountTriggerData>
    {
        [SerializeField] private string _tag;
        [SerializeField] private Type _type = Type.None;
        [SerializeField] private CountData _initial;
        [SerializeField] private CountData _delta;

        private CountData _currentData;
        
        [UsedImplicitly]
        private void Awake()
        {
            _currentData = _initial;
        }

        public override CountTriggerData GetData()
        {
            switch (_type)
            {
                case Type.Add:
                    _currentData += _delta;
                    break;
                case Type.Subtract:
                    _currentData -= _delta;
                    break;
                case Type.None:
                default:
                    break;
            }

            var result = new CountTriggerData(_tag, _currentData);
            return result;
        }

        public enum Type
        {
            None,
            Add,
            Subtract
        }
    }
}