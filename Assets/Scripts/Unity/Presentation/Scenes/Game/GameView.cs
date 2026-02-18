using System;
using Core.Domain.Services.Windows;
using Unity.Presentation.Windows;
using UnityEngine;
using Zenject;

namespace Unity.Presentation
{
    public class GameView : MonoBehaviour
    {
        public event Action OnDisconnectClick;
        public event Action OnShowExampleWindowClick;
        
        
        public void DisconnectClicked()
        {
            OnDisconnectClick?.Invoke();
        }
        
        public void ShowExampleWindowClick()
        {
            OnShowExampleWindowClick?.Invoke();
        }
    }
}