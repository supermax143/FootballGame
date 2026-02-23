using System;
using System.Collections.Generic;
using System.Linq;
using Environments.Common.Scripts;
using JetBrains.Annotations;
using Unity.Infrastructure.Camera;
using UnityEngine;

using Zenject;

namespace Environments.Land.Scripts.Runtime.Controllers.Touch.Handlers
{
    public class FieldTouchHandler : ITouchHandler, IInitializable
    {
        public event Action<TouchData> OnLandClick;
        
        [Inject] private ITouchController _touchController;
        [Inject] private ICameraController _cameraController;
        
        public TouchHandlerType Type => TouchHandlerType.GameField;

        private ClickHandleComponent _curTarget;
        
        public void Initialize()
        {
            _touchController.AddHandler(this);
        }
        
        public bool OnTouchBegin(IReadOnlyCollection<TouchData> touches)
        { 
            if (_touchController.Blocked)
            {
                return false;
            }

            var touch = touches.First();

            if (!TryGetHitTarget(touch, out var target))
                return false;
                
            target.HandleTouchBegin(touch);
            _curTarget = target;
            return false;
        }

        public void OnTouchEnd(IReadOnlyCollection<TouchData> touches)
        {
            if (_curTarget == null)
            {
                return;
            }
        
            _curTarget.OnTouchEnd();
            _curTarget = null;
        }

        public void OnTouchMove(IReadOnlyCollection<TouchData> touches)
        {
            if (_curTarget == null)
            {
                return;
            }

            _curTarget.OnTouchEnd();
            _curTarget = null;
        }


        bool ITouchHandler.TryConsumeClick(TouchData touch)
        {
            if (_touchController.Blocked)
            {
                return false;
            }

            if (TryGetHitTarget(touch, out var target) && target.HandleClick())
            {
                return true;
            }
            
            OnLandClick?.Invoke(touch);
            
            return true;
        }

        private bool TryGetHitTarget(TouchData touch, out ClickHandleComponent target)
        {
            target = default;
            var hit = Physics2D.Raycast(_cameraController.ScreenToWorldPoint(touch.MousePosition),
                Vector3.zero);

            return hit.collider && hit.collider.TryGetComponent(out target);
        }

       
    }
}
