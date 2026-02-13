using System;
using Core.Domain.Services.ApplicationSession;
using Unity.Netcode;
using Zenject;

namespace Unity.Infrastructure.Network
{
    public class NetworkController : INetworkController, IInitializable
    {

        [Inject] private IApplicationSession _session;
        [Inject] private NetworkManager _networkManager;
        
        
        
        
        public void Initialize()
        {
            _networkManager.OnServerStarted += ServerStartedHandler;
            _networkManager.OnClientConnectedCallback += ClientConnectedHandler;
            _networkManager.OnClientDisconnectCallback += ClientDisconnectHandler;
            _networkManager.OnConnectionEvent += ConnectionEventHandler;
        }

        private void ConnectionEventHandler(NetworkManager manager, ConnectionEventData data)
        {
            switch (data.EventType)
            {
                case ConnectionEvent.ClientConnected:
                    _session.CurrentState.ClientConnectedHandler(data.ClientId);
                    break;
                case ConnectionEvent.ClientDisconnected:
                    _session.CurrentState.ClientDisconnectHandler(data.ClientId);
                    break;
            }
        }

        private void ClientConnectedHandler(ulong id)
        {
            _session.CurrentState.ClientConnectedHandler(id);
        }
        
        private void ClientDisconnectHandler(ulong id)
        {
            _session.CurrentState.ClientDisconnectHandler(id);
        }


        private void ServerStartedHandler()
        {
            _session.CurrentState.ServerStartedHandler();
        }

        public void StartServer()
        {
            _networkManager.StartServer();
        }
        
        public void StartHost()
        {
            _networkManager.StartHost();
        }
        
        public void StartClient()
        {
            _networkManager.StartClient();
        }

    }
    
}