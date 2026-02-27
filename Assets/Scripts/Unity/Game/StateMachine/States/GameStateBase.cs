using UnityEngine;
using Zenject;

namespace Unity.Game
{
    internal abstract class GameStateBase : MonoBehaviour
    {
        [Inject] protected GameStateManager _gameStateManager;
        [Inject] protected GameModel _gameModel;
        
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