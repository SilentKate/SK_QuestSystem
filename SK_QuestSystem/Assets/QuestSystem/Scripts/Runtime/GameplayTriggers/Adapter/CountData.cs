using System;
using UnityEngine;

namespace QuestSystem.Scripts.Runtime.GameplayTriggers.Adapter
{
    [Serializable]
    public struct CountData
    {
        [SerializeField] private int _count;
        public int Count => _count;

        public CountData(int count)
        {
            _count = count;
        }
        
        public static CountData operator +(CountData x, CountData y)
        {
            return new CountData(x.Count + y.Count);
        }
        
        public static CountData operator -(CountData x, CountData y)
        {
            return new CountData(x.Count - y.Count);
        }
    }
}