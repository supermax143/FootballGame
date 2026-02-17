using System.Collections.Generic;
using Shared.Constants;
using Unity.Infrastructure.Network;
using Zenject;

namespace Core.Application.Game
{
    internal class GameSessionController
    {
        [Inject] private INetworkController _networkController;
        
        public void Initialize(List<ulong> clients)
        {
            foreach (var client in clients)
            {
                // _networkController.LoadSceneOnClient(client, SceneNames.GameScene);
            }
        }
    }
}