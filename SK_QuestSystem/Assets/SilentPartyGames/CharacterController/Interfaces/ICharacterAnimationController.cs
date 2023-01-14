using System.Threading.Tasks;

namespace SilentPartyGames.CharacterController.Interfaces
{
    public interface ICharacterAnimationController
    {
        void Show(IAnimation animation, bool addictive);
    }

    public interface IAnimation
    {
        Task AnimateAsync();
    }
}