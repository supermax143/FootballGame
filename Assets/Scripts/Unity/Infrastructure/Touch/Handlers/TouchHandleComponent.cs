using System;
using Environments.Common.Scripts;
using UnityEngine;

namespace Environments.Land.Scripts.Runtime.Controllers.Touch.Handlers
{
    public class TouchHandleComponent : MonoBehaviour
    {
        public event Action<TouchData> OnTouchBegin;
        public event Action OnTouchEnd;
        public event Action<Vector2> OnTouchMove;
        public event Action OnClick;
        
        
        public void HandleTouchBegin(TouchData touch)
        {
            OnTouchBegin?.Invoke(touch);
        }

        public void HandleTouchEnd()
        {
            Debug.Log("HandleTouchEnd");
            OnTouchEnd?.Invoke();
        }
        
        public void HandleTouchMove(Vector2 delta)
        {
            transform.Translate(-delta);
            Debug.Log($"HandleTouchMove: {delta}");
            OnTouchMove?.Invoke(delta);
        }
       
        public bool HandleClick()
        {
            Debug.Log("HandleClick");
            OnClick?.Invoke();
            return true;
        }
    }
}