using Environments.Common.Scripts;
using UnityEngine;

namespace Environments.Land.Scripts.Runtime.Controllers.Touch.Handlers
{
    internal class ClickHandleComponent : MonoBehaviour
    {
        public void HandleTouchBegin(TouchData touch)
        {
        }

        public void OnTouchEnd()
        {
        }

        public bool HandleClick()
        {
            return true;
        }
    }
}