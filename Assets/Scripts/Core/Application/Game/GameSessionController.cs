using System.Collections.Generic;
using Shared.Constants;
using Unity.Infrastructure.Network;
using Zenject;

namespace Core.Application.Game
{
    internal class GameSessionController
    {
        [Inject] private INetworkController _networkController;

        private List<ulong> _clients;
        
        public void Initialize(List<ulong> clients)
        {
            _clients = clients;
            foreach (var client in clients)
            {
                _networkController.LoadSceneOnClient(client, SceneNames.GameScene);
            }
        }

        public void StopGame()
        {
            
        }

        public bool HasClient(ulong id)
        {
            return _clients.Contains(id);
        }
    }
}