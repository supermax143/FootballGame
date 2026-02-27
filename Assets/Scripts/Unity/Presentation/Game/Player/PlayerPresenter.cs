using System;
using Core.Domain.Models;
using Environments.Land.Scripts.Runtime.Controllers.Touch.Handlers;
using Unity.Infrastructure.Camera;
using Unity.Infrastructure.Settings;
using UnityEngine;
using Unity.Netcode;
using Zenject;

namespace Unity.Game
{
    /// <summary>
    /// Presenter component for Player.
    /// Coordinates between the domain model and the view.
    /// </summary>
    [RequireComponent(typeof(PlayerView))]
    [RequireComponent(typeof(NetworkObject))]
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        private PlayerView _view;
        [SerializeField, HideInInspector]
        private TouchHandleComponent _touchHandler;
        [SerializeField, HideInInspector]
        private NetworkObject _networkObject;

        [Inject] private GameSettings _gameSettings;
        [Inject] private ICameraController _cameraController;
        
        private Player _playerModel;

        private void OnValidate()
        {
            _view = GetComponent<PlayerView>();
            _touchHandler = GetComponent<TouchHandleComponent>();
            _networkObject = GetComponent<NetworkObject>();
        }

        private void Start()
        {
            _touchHandler.OnTouchMove += HandleTouchMove;
        }

        private void HandleTouchMove(Vector2 obj)
        {
        }

        public void Initialize(Player player)
        {
            _playerModel = player;
            UpdateView();
        }

       
        private void UpdateView()
        {
            if (_playerModel == null || _view == null)
                return;

            var color = _playerModel.TeamIndex == 0 ? _gameSettings.Team1Color : _gameSettings.Team2Color;
            
            _view.SetSpriteColor(color);
        }

    }
}

