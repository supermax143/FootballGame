using System;
using Core.Domain.Services;
using Unity.Netcode;
using Zenject;

namespace Unity.Infrastructure.Network
{
    public class NetworkRPC : NetworkBehaviour
    {
        [Inject] private IScenesLoader _scenesLoader;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void LoadSceneOnClient(ulong clientId, string sceneName)
        {
            if (!IsServer)
            {
                return;
            }
           
            var rpcParams = new RpcParams();
            rpcParams.Send.Target = RpcTarget.Single(clientId, RpcTargetUse.Temp);
            
            LoadSceneOnClientRPC(sceneName, rpcParams);
        }
        
        [Rpc(SendTo.SpecifiedInParams)]
        private void LoadSceneOnClientRPC(string sceneName, RpcParams rpcParams = default)
        {
            _scenesLoader.LoadScene(sceneName);
        }
    }
}