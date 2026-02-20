using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine.SceneManagement;

namespace Unity.Infrastructure.Network.RPC
{
    internal partial class NetworkRPC
    {
        public void LoadSceneOnClient(ulong clientId, string sceneName)
        {
            NetworkManager.Singleton.SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            //LoadSceneOnClientRPC(sceneName, ClientParams(clientId));
        }
        
        [Rpc(SendTo.SpecifiedInParams)]
        private void LoadSceneOnClientRPC(string sceneName, RpcParams rpcParams = default)
        {
            _scenesLoader.LoadScene(sceneName);
        }
        
       
    }
}
