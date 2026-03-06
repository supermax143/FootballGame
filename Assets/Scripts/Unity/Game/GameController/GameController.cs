using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Presentation;
using UnityEngine;
using Zenject;

namespace Unity.Game
{
    public class GameController : NetworkBehaviour, IGameController
    {
        [Inject] private IGameModel _gameModel;
        [Inject] private GameFieldPresenter _gameField;
        [Inject] private GameScenePresenter _gameScene;
        
        public void Initialize()
        {
            InitializeRPC();
        }

        [Rpc(SendTo.ClientsAndHost)]
        private void InitializeRPC()
        {
            InitializeAsynch();
        }

        private async Task InitializeAsynch()
        {
            await _gameField.Initialize();
            _gameScene.Initialize();
        }
        
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