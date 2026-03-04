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
            _gameModel.Initialize();
            var playerId = _gameSession.Players
                .ToArray()[Random.Range(0, _gameSession.Players.Count())].Id;
            _gameModel.SetActivePlayerId(playerId);
            
            var playerPrefab = await _gameSettings.PlayerPrefab.LoadAssetAsync<GameObject>();
            foreach (var player in _gameSessionController.Players)
            {
                var points = _gameFieldPresenter.GetTeamSpawnPoints(player.TeamIndex);
                InitTeam(player.Id, points, playerPrefab);
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