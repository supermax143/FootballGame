using Unity.Infrastructure.Network;
using UnityEngine;
using Zenject;

namespace Unity.Game
{
    internal class GameStateMachine : MonoBehaviour
    {
        [Inject] private DiContainer _container;
        [Inject] private INetworkController _networkController;
        
        private GameStateBase _currentState;

        public void Start()
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