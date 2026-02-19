using UnityEngine;

namespace Unity.Game
{
    internal abstract class GameStateBase : MonoBehaviour
    {
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