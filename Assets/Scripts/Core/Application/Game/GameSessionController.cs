using System.Collections.Generic;
using System.Linq;
using Core.Domain.Models;
using Shared.Constants;
using Unity.Infrastructure.Network;
using Zenject;

namespace Core.Application.Game
{
    internal class GameSessionController : IGameSessionController
    {
        [Inject] private INetworkController _networkController;

        private readonly List<Player> _players = new();

        public IEnumerable<Player> Players => _players;

        public void Initialize(List<ulong> clients)
        {
            if (clients.Count == 0 || clients.Count > 2)
            {
                return;
            }
            _players.Clear();
            int teamIndex = 0;
            foreach (var clientId in clients)
            {
                _players.Add(new Player(clientId, $"Player{clientId}", teamIndex++));
                _networkController.LoadSceneOnClient(clientId, SceneNames.GameScene);
            }
        }

        public void StopGame()
        {
            
        }

        public bool HasPlayer(ulong id)
        {
            return _players.Any(p => p.Id == id);
        }
    }
}