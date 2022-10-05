using QuestSystem.Scripts.Runtime.GameplayTriggers.Adapter;

namespace QuestSystem.Scripts.Runtime.GameplayTriggers.Data
{
    public class CountTriggerData : ITriggerData
    {
        public CountTriggerData(string tag, CountData data)
        {
            Tag = tag;
            Data = data;
        }

        public string Tag { get; }
        public CountData Data { get; }
    }
}