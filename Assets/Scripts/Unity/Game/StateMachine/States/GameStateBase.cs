using Core.Application.Game;
using UnityEngine;
using Zenject;

namespace Unity.Game
{
    internal abstract class GameStateBase : MonoBehaviour
    {
        [Inject] protected GameStateManager _gameStateManager;
        [Inject] protected GameModel _gameModel;
        [Inject] protected IGameSessionController _gameSession;
        
        private void Start()
        {
            OnStateEnter();
        }

        

        private void OnDestroy()
        {
            OnStateExit();
        }

        protected virtual void OnStateExit()
        {
            
        }

        protected virtual void OnStateEnter()
        {
            
        }
    }
}