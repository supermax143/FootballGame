using System;
using Core.Application.Game;
using ModestTree;
using Unity.Infrastructure.Network;
using Unity.Netcode;
using UnityEngine;
using Zenject;

namespace Unity.Game
{
    internal class GameStateMachine : NetworkBehaviour
    {
        [Inject] private DiContainer _container;
        [Inject] private INetworkController _networkController;
        [Inject] private IGameSessionController _gameSessionController;
        
        private GameStateBase _currentState;

        private void Start()
        {
            if (_gameSessionController == null || 
                _gameSessionController.Clients == null || 
                !_gameSessionController.Clients.IsEmpty())
            {
                return;
            }
            ChangeState<InitializeGameOfflineState>();
        }

        public override void OnNetworkSpawn()
        {
            if (!_networkController.IsServer)
            {
                return;
            }
            ChangeState<InitializeGameState>();
        }
        
        internal void ChangeState<TState>() where TState : GameStateBase
        {
            var newState = _container.InstantiateComponent<TState>(gameObject);
            ChangeState(newState);
        }
      
        private void ChangeState(GameStateBase newState)
        {
            if (_currentState != null)
            {
                Destroy(_currentState);
            }
            
            _currentState = newState;
        }
    }
}