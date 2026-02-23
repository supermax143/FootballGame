using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Application.Game;
using Cysharp.Threading.Tasks;
using Unity.Infrastructure.ResourceManager;
using Unity.Infrastructure.Settings;
using Unity.Netcode;
using UnityEngine;
using Zenject;

namespace Unity.Game
{
    internal class InitializeGameState : GameStateBase
    {
        
        [Inject] private GameFieldPresenter _gameFieldPresenter;
        [Inject] private GameSettings _gameSettings;
        [Inject] private IGameSessionController _gameSessionController;
        
        protected override void OnStateEnter()
        {
            InitializeGame();
        }
        
        private async Task InitializeGame()
        {
            var playerPrfab = await _gameSettings.PlayerPrefab.LoadAssetAsync<GameObject>();
            for (int i = 0; i < _gameSessionController.Clients.Count; i++)
            {
                var clientId = _gameSessionController.Clients[i];
                var points = _gameFieldPresenter.GetTeamSpawnPoints((uint)i);
                InitTeam(clientId, points, playerPrfab);
            }
        }
        
        private void InitTeam(ulong clientId, IEnumerable<Transform> placers, GameObject playerPrfab)
        {
            foreach (var placer in placers)
            {
                var player = Instantiate(playerPrfab, placer.position, Quaternion.identity, _gameFieldPresenter.GameFieldTransform);
                var networkObject = player.GetComponent<NetworkObject>();
                networkObject.SpawnWithOwnership(clientId);
            }
        }
        
        
        
    }
}