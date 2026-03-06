using System;
using Core.Domain.Services.ApplicationSession;
using Core.Domain.Services.Windows;
using Unity.Presentation.Windows;
using UnityEngine;
using Zenject;

namespace Unity.Presentation
{
    [RequireComponent(typeof(GameSceneView))]
    public class GameScenePresenter : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        private GameSceneView _view;

        [Inject] private IWindowsController _windowsController;
        [Inject] private IApplicationSession _session;
        
        private void OnValidate()
        {
            _view = GetComponent<GameSceneView>();
        }
        
        public void Initialize()
        {
            _view.UpdateView();
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