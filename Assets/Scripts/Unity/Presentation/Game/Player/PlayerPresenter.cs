using System;
using Core.Domain.Models;
using Environments.Land.Scripts.Runtime.Controllers.Touch.Handlers;
using Unity.Infrastructure.Camera;
using Unity.Infrastructure.Network;
using Unity.Infrastructure.Settings;
using UnityEngine;
using Unity.Netcode;
using Zenject;

namespace Unity.Game
{
    
    public class PlayerPresenter : NetworkBehaviour
    {
        public event Action<PlayerPresenter, Vector2> OnTouchInputMove;
        
        
        [SerializeField, HideInInspector]
        private PlayerView _view;
        [SerializeField, HideInInspector]
        private TouchHandleComponent _touchHandler;
        [SerializeField, HideInInspector]
        private NetworkObject _networkObject;

        [Inject] private GameSettings _gameSettings;
        [Inject] private ICameraController _cameraController;
        [Inject] private IGameModel _gameModel;
        [Inject] private INetworkObjectSpawnHandler _spawnHandler;
        
        
        private PlayerData _player;

        public ulong PlayerId => _player.Id;
        
        private void OnValidate()
        {
            _view = GetComponent<PlayerView>();
            _touchHandler = GetComponent<TouchHandleComponent>();
            _networkObject = GetComponent<NetworkObject>();
        }
        

        public override void OnNetworkSpawn()
        {
            _touchHandler.OnTouchMove += HandleTouchMove;
            Initialize();
            _spawnHandler.RaiseSpawnEvent(this);
        }

        
        private void Initialize()
        {
            if (!_gameModel.TryGetPlayer(OwnerClientId ,out _player))
            {
                return;
            }
            UpdateView();
            Show();
        }
        
        private void HandleTouchMove(Vector2 touchMove)
        {
            OnTouchInputMove?.Invoke(this, touchMove);
        }
       
        private void UpdateView()
        {
            var color = _player.TeamIndex == 0 ? _gameSettings.Team1Color : _gameSettings.Team2Color;
            _view.SetSpriteColor(color);
        }

        private void Show() => gameObject.SetActive(true);
        private void Hide() => gameObject.SetActive(false);

        public void ApplyForce(Vector2 force)
        {
            throw new NotImplementedException();
        }
    }
}

