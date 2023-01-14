namespace SilentPartyGames.CharacterController.Interfaces
{
    public interface ICharacterAbilityController
    {
        void Use(IAbility ability);
    }

    public interface IAbility
    {
        double Cooldown { get; }
    }
}