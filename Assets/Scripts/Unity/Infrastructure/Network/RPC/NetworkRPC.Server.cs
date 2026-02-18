using System.Collections.Generic;
using Unity.Netcode;

namespace Unity.Infrastructure.Network.RPC
{
    internal partial class NetworkRPC
    {
        public void LoadSceneOnClient(ulong clientId, string sceneName)
        {
            LoadSceneOnClientRPC(sceneName, ClientParams(clientId));
        }
        
        [Rpc(SendTo.SpecifiedInParams)]
        private void LoadSceneOnClientRPC(string sceneName, RpcParams rpcParams = default)
        {
            _scenesLoader.LoadScene(sceneName);
        }
        
       
    }
}
