using System;
using Environments.Common.Scripts;
using UnityEngine;

namespace Environments.Land.Scripts.Runtime.Controllers.Touch.Handlers
{
    public class TouchHandleComponent : MonoBehaviour
    {
        public event Action<Vector2> OnTouchBegin;
        public event Action OnTouchEnd;
        public event Action<Vector2> OnTouchMove;
        public event Action OnClick;
        
        
        public void HandleTouchBegin(TouchData touch)
        {
            OnTouchBegin?.Invoke(touch.MousePosition);
        }

        public void HandleTouchEnd()
        {
            Debug.Log("HandleTouchEnd");
            OnTouchEnd?.Invoke();
        }
        
        public void HandleTouchMove(Vector2 touchMove)
        {
            Debug.Log($"HandleTouchMove: {touchMove}");
            OnTouchMove?.Invoke(touchMove);
        }
       
        public bool HandleClick()
        {
            Debug.Log("HandleClick");
            OnClick?.Invoke();
            return true;
        }
    }
}