namespace SilentPartyGames.CharacterController.Attributes
{
    public enum AttributeModifierTarget
    {
        Base,
        Total
    }
    
    public class AttributeModifier
    {
        public AttributeModifier(
            float value,
            AttributeModifierTarget target = AttributeModifierTarget.Total,
            int order = 0)
        {
            Value = value;
            Target = target;
            Order = order;
        }

        public float Value { get; }
        public AttributeModifierTarget Target { get; }
        public int Order { get; }
        public float Apply(float value)
        {
            return value;
        }
    }
}