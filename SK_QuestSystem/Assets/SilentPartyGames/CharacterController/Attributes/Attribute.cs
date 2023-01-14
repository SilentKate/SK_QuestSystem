using System.Collections.Generic;

namespace SilentPartyGames.CharacterController.Attributes
{
    public class Attribute
    {
        private const float MaxModifiersWeight = 1.0f;
        
        private readonly List<AttributeModifier> _baseModifiers = new(2);
        private readonly List<AttributeModifier> _totalModifiers = new(2);

        public Attribute(float baseValue)
        {
            BaseValue = baseValue;
            ModifiedBaseValue = BaseValue;
            ModifiedTotalValue = BaseValue;
        }
        
        public float BaseValue { get; }

        public float ModifiedBaseValue { get; private set; }
        public float ModifiedTotalValue { get; private set; }

        public Attribute AddModifier(AttributeModifier modifier)
        {
            var targetCollection 
                = modifier.Target == AttributeModifierTarget.Base
                    ? _baseModifiers
                    : _totalModifiers;
            targetCollection.Add(modifier);
            return this;
        }

        public Attribute RemoveModifier(AttributeModifier modifier)
        {
            var targetCollection 
                = modifier.Target == AttributeModifierTarget.Base
                    ? _baseModifiers
                    : _totalModifiers;
            targetCollection.Remove(modifier);
            return this;
        }

        // TODO: learn data structures and optimize
        public void Recalculate()
        {
            _baseModifiers.Sort(Compare);
            _totalModifiers.Sort(Compare);
            
            for (var i = 0; i < _baseModifiers.Count; i++)
            {
                var modifier = _baseModifiers[i];
                ModifiedBaseValue = modifier.Apply(ModifiedBaseValue);
            }

            ModifiedTotalValue = ModifiedBaseValue;
            for (var i = 0; i < _totalModifiers.Count; i++)
            {
                var modifier = _baseModifiers[i];
                ModifiedTotalValue = modifier.Apply(ModifiedTotalValue);
            }
        }

        private int Compare(AttributeModifier x, AttributeModifier y)
        {
            return x.Order.CompareTo(y.Order);
        }
    }
}