using Unity.Netcode;
using Zenject;

namespace Unity.Game
{
    internal class InitializeGameState : GameStateBase
    {
        [Inject] private GameSettings _gameSettings;
        
        protected override void OnStateEnter()
        {
            
        }
    }
}