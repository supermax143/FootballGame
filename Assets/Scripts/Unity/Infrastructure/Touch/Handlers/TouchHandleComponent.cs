using Environments.Common.Scripts;
using UnityEngine;

namespace Environments.Land.Scripts.Runtime.Controllers.Touch.Handlers
{
    internal class TouchHandleComponent : MonoBehaviour
    {
        public void HandleTouchBegin(TouchData touch)
        {
            Debug.Log("HandleTouchBegin");
        }

        public void HandleTouchEnd()
        {
            Debug.Log("HandleTouchEnd");
        }
        
        public void HandleTouchMove(Vector2 delta)
        {
            transform.Translate(-delta);
            Debug.Log($"HandleTouchMove: {delta}");
        }
       
        public bool HandleClick()
        {
            Debug.Log("HandleClick");
            return true;
        }
    }
}