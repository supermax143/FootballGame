using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Unity.Infrastructure.Settings;
using Unity.Netcode;
using UnityEngine;
using Zenject;

namespace Unity.Game
{
    internal class InitializeGameOfflineState : GameStateBase
    {
        
        [Inject] private GameFieldPresenter _gameFieldPresenter;
        [Inject] private GameSettings _gameSettings;
        
        
        protected override void OnStateEnter()
        {
            InitializeGame();
        }
        
        private async Task InitializeGame()
        {
            var playerPrfab = await _gameSettings.PlayerPrefab.LoadAssetAsync<GameObject>();
            for (int i = 0; i < 2; i++)
            {
                var clientId = i;
                var points = _gameFieldPresenter.GetTeamSpawnPoints((uint)i);
                InitTeam((ulong)clientId, points, playerPrfab);
            }
        }
        
        private void InitTeam(ulong clientId, IEnumerable<Transform> placers, GameObject playerPrfab)
        {
            foreach (var placer in placers)
            {
                var player = Instantiate(playerPrfab, placer.position, Quaternion.identity, _gameFieldPresenter.GameFieldTransform);
                // var networkObject = player.GetComponent<NetworkObject>();
                // networkObject.SpawnWithOwnership(clientId);
            }
        }
    }
}