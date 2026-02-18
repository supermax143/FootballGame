using System;
using Core.Domain.Services.ApplicationSession;
using Core.Domain.Services.Windows;
using Unity.Presentation.Windows;
using UnityEngine;
using Zenject;

namespace Unity.Presentation
{
    [RequireComponent(typeof(GameView))]
    public class GemePresenter : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        private GameView _view;

        [Inject] private IWindowsController _windowsController;
        [Inject] private IApplicationSession _session;
        
        private void OnValidate()
        {
            _view = GetComponent<GameView>();
        }

        private void Start()
        {
            _view.OnDisconnectClick += DisconnectClickHandler;
            _view.OnShowExampleWindowClick += ShowExampleWindowClickHandler;
        }

        private void ShowExampleWindowClickHandler()
        {
            _windowsController.ShowWindow<ExampleWindow>( window => window.Show());

        }

        private void DisconnectClickHandler()
        {
            _session.CurrentState.Disconnect();
        }
    }
}