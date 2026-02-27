using Zenject;

namespace Unity.Game
{
    internal class InGameState : GameStateBase
    {
        
        protected override void OnStateEnter()
        {
            _ga
            _gameModel.SetActivePlayerId();
        }
    }
}