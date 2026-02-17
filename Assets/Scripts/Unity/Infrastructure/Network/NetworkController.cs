using Core.Domain.Services.ApplicationSession;
using Unity.Netcode;
using UnityEngine;
using Zenject;

namespace Unity.Infrastructure.Network
{
    public class NetworkController : MonoBehaviour, INetworkController, IInitializable
    {

        [SerializeField]
        private GameObject _networkRPCPrefab;
        
        [Inject] private IApplicationSession _session;
        [Inject] private NetworkManager _networkManager;
        
        public void Initialize()
        {
            _networkManager.OnServerStarted += ServerStartedHandler;
            _networkManager.OnServerStopped += ServerStoppedHandler;
            _networkManager.OnClientConnectedCallback += ClientConnectedHandler;
            _networkManager.OnClientDisconnectCallback += ClientDisconnectHandler;
            _networkManager.OnConnectionEvent += ConnectionEventHandler;
        }

        public bool IsLocalClient(ulong clientId)
        {
            return _networkManager.LocalClient != null && 
                   clientId == _networkManager.LocalClient.ClientId;
        }
        
        private void ConnectionEventHandler(NetworkManager manager, ConnectionEventData data)
        {
            var local = IsLocalClient(data.ClientId);
            
            switch (data.EventType)
            {
                case ConnectionEvent.ClientConnected:
                    _session.CurrentState.ClientConnectedHandler(data.ClientId, local);
                    break;
                case ConnectionEvent.ClientDisconnected:
                    _session.CurrentState.ClientDisconnectHandler(data.ClientId, local);
                    break;
            }
        }

        private void ClientConnectedHandler(ulong id)
        {
            _session.CurrentState.ClientConnectedHandler(id, IsLocalClient(id));
        }
        
        private void ClientDisconnectHandler(ulong id)
        {
            _session.CurrentState.ClientDisconnectHandler(id, IsLocalClient(id));
        }


        private void ServerStartedHandler()
        {
            _session.CurrentState.ServerStartedHandler();
        }

        private void ServerStoppedHandler(bool value)
        {
            _session.CurrentState.ServerStoppedHandler();
        }
        
        public void StartServer()
        {
            _networkManager.StartServer();
        }


        public void StartHost()
        {
            _networkManager.StartHost();
        }

        public void StopHost()
        {
            _networkManager.Shutdown();
        }

        public void StartClient()
        {
            _networkManager.StartClient();
        }

        public void Disconnect()
        {
            _networkManager.Shutdown();
        }
        
        // public void LoadSceneOnClient(ulong clientId, string sceneName)
        // {
        //     if (!_networkManager.IsServer)
        //     {
        //         return;
        //     }
        //    
        //     var rpcParams = new RpcParams();
        //     rpcParams.Send.Target = RpcTarget.Single(clientId, RpcTargetUse.Temp);
        //     
        //     LoadSceneOnClientRPC(sceneName, rpcParams);
        // }
        //
        // [Rpc(SendTo.SpecifiedInParams)]
        // private void LoadSceneOnClientRPC(string sceneName, RpcParams rpcParams = default)
        // {
        //     _scenesLoader.LoadScene(sceneName);
        // }
        
    }
    
}