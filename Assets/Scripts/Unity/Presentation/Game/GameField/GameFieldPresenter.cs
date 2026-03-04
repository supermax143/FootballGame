using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Services;
using Unity.Infrastructure.Camera;
using UnityEngine;
using Zenject;

namespace Unity.Game
{
    [RequireComponent(typeof(GameFieldView))]
    public class GameFieldPresenter : MonoBehaviour
    {
        
        [Inject] private INetworkObjectSpawnObserver _spawnObserver;
        [Inject] private ICameraController _cameraController;
        
        [SerializeField, HideInInspector]
        private GameFieldView _view;

        private readonly List<PlayerPresenter> _players = new();
        public Transform GameFieldTransform => _view.transform;
        
        private void OnValidate()
        {
            _view = GetComponent<GameFieldView>();
        }

        private void Start()
        {
            _spawnObserver.SubscribeSpawn<PlayerPresenter>(OnPlayerSpawned);
        }

        private void OnPlayerSpawned(PlayerPresenter player)
        {
            if (_players.Contains(player))
            {
                return;
            }
            
            _players.Add(player);
            if (player.IsOwner)
            {
                player.OnTouchInputMove += HandleTouchInputMove;
            }
            
            Debug.Log($"Player {player.PlayerId} has been spawned");
        }

        private void HandleTouchInputMove(PlayerPresenter player, Vector2 touchMove)
        {
            var delta = _cameraController.ScreenToViewportPoint(touchMove);
            player.transform.Translate(delta);
        }

        public void MovePlayer(ulong clientId, Vector2 force)
        {
            if (!TryGetPlayer(clientId, out var player))
            {
                Debug.Log($"Can't find player {clientId}");
            }

            player.ApplyForce(force);
        }

        private bool TryGetPlayer(ulong clientId, out PlayerPresenter player)
        {
            player = _players.FirstOrDefault(p => p.PlayerId == clientId);
            return player != null;
        }
        
        public IEnumerable<Transform> GetTeamSpawnPoints(int index)
        {
            if (index > 1)
                yield break;

            var points = index == 0 
                ? _view.SpawnPointsTeam1 
                : _view.SpawnPointsTeam2;

            foreach (var point in points)
                yield return point;
        }

        private void OnDestroy()
        {
            _spawnObserver.UnsubscribeSpawn<PlayerPresenter>(OnPlayerSpawned);
        }
    }
}