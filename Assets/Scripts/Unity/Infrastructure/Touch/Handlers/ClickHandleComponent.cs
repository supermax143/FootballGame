using Environments.Common.Scripts;
using UnityEngine;

namespace Environments.Land.Scripts.Runtime.Controllers.Touch.Handlers
{
    internal class ClickHandleComponent : MonoBehaviour
    {
        public void HandleTouchBegin(TouchData touch)
        {
            Debug.Log("HandleTouchBegin");
        }

        public void OnTouchEnd()
        {
            Debug.Log("OnTouchEnd");
        }

        public bool HandleClick()
        {
            Debug.Log("HandleClick");
            return true;
        }
    }
}