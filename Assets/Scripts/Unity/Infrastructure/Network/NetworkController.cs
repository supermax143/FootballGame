using Core.Domain.Services;
using Core.Domain.Services.ApplicationSession;
using Unity.Infrastructure.Network.RPC;
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
        [Inject] private DiContainer _container;
        [Inject] private INetworkObjectSpawnObserver _spawnObserver;
        
        private NetworkRPC _networkRPC;
        
        public void Initialize()
        {
            _networkManager.OnServerStarted += ServerStartedHandler;
            _networkManager.OnServerStopped += ServerStoppedHandler;
            _networkManager.OnClientConnectedCallback += ClientConnectedHandler;
            _networkManager.OnClientDisconnectCallback += ClientDisconnectHandler;
            _networkManager.OnConnectionEvent += ConnectionEventHandler;
            _spawnObserver.SubscribeSpawn<NetworkRPC>(OnRpcSpawned);
            _spawnObserver.SubscribeDespawn<NetworkRPC>(OnRpcDespawned);
        }


        private void OnRpcSpawned(NetworkRPC rpc)
        {
            if (!rpc.IsOwner)
            {
                return;
            }
            _networkRPC = rpc;
        }
        
        private void OnRpcDespawned(NetworkRPC rpc)
        {
            if (!rpc.IsOwner || _networkRPC != rpc)
            {
                return;
            }
            _networkRPC = null;
        }
        

        public bool IsLocalClient(ulong clientId)
        {
            return _networkManager.LocalClient != null && 
                   clientId == _networkManager.LocalClient.ClientId;
        }
        
        public bool IsServer => _networkManager.IsServer;
        public bool IsClient => _networkManager.IsClient;
        public bool IsHost => _networkManager.IsHost;
        
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
            SpawnNetworkRPC();
            _session.CurrentState.ServerStartedHandler();
        }

        private void SpawnNetworkRPC()
        {
            if (!_networkManager.IsServer)
            {
                return;
            }
            var go = Instantiate(_networkRPCPrefab);
            go.GetComponent<NetworkObject>().Spawn();
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

        public void LoadSceneOnClient(ulong clientId, string sceneName)
        {
            _networkRPC.LoadSceneOnClient(clientId, sceneName);
        }
        
       
        
    }
    
}