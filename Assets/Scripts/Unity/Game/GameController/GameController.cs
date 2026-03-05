using Unity.Netcode;
using UnityEngine;
using Zenject;

namespace Unity.Game
{
    public class GameController : NetworkBehaviour, IGameController
    {
        [Inject] private IGameModel _gameModel;
        [Inject] private GameFieldPresenter _gameField;


        public void MakeTurn(ulong clientId, Vector2 force)
        {
            MakeTurnRPC(clientId, force);
        }
        
        [Rpc(SendTo.Server)]
        private void MakeTurnRPC(ulong clientId, Vector2 force)
        {
            if (_gameModel.ActivePlayerId.Value != clientId)
            {
                return;
            }
            
            if (!_gameField.TryGetPlayer(clientId, out var player))
            {
                Debug.Log($"Client {clientId} doesn't exist");
                return;
            }
            _gameField.MovePlayer(clientId, force);
            _gameModel.EndTurn();
        }
    }
}