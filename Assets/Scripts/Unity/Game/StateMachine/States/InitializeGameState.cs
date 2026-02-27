using System.Collections.Generic;
using System.Linq;
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
            var playerPrefab = await _gameSettings.PlayerPrefab.LoadAssetAsync<GameObject>();
            int index = 0;
            foreach (var player in _gameSessionController.Players)
            {
                var points = _gameFieldPresenter.GetTeamSpawnPoints((uint)index);
                InitTeam(player.Id, points, playerPrefab);
                index++;
            }
            
            _gameStateManager.ChangeState<InGameState>();
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