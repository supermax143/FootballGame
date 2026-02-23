using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Application.Game;
using Core.Application.Models;
using Core.Domain.Models;
using Unity.Infrastructure.Network;
using UnityEngine;
using Zenject;

namespace Core.Application.ApplicationSession.States
{
    internal class HostingState : SessionStateBase
    {
        
        [Inject] private INetworkController _networkController;
        [Inject] private IClientModelInternal _clientModel;
        [Inject] private DiContainer _container;
        [Inject] private GameSessionController _gameSession;
        
        private List<ulong> _clients = new();
        
        

        public override void Disconnect()
        {
            _networkController.StopHost();
            _clients.Clear();
            StopGameSession();
        }

        public override void ServerStoppedHandler()
        {
            ApplicationStateMachine.ChangeState<OfflineState>();
        }

        public override void ClientConnectedHandler(ulong id, bool local)
        {
            if (_clients.Contains(id))
            {
                return;
            }
            _clients.Add(id);
            if (local)
            {
                AddLocalClient(id);
            }

            if (_clients.Count == 2)
            {
                CreateGameSession(_clients);
            }
            
            Debug.Log("ClientConnected:");
            ShowCurrentClients();
        }
        
        public override void ClientDisconnectHandler(ulong id, bool local)
        {
            if (!_clients.Contains(id))
            {
                return;
            }
            _clients.Remove(id);
            StopGameSessionIfRequire(id);
            Debug.Log("ClientDisconnect:");
            ShowCurrentClients();
        }

        protected override Task OnStateEnter()
        {
            ApplicationStateMachine.ConnectionStatus = ConnectionStatus.Connected;
            return Task.CompletedTask;
        }
        
        private void StopGameSessionIfRequire(ulong id)
        {
            if(_gameSession == null || !_gameSession.HasClient(id))
            { 
                return; 
            }
            StopGameSession();
        }
        
        private void StopGameSession()
        {
            _gameSession.StopGame();
            _gameSession = null;
        }
        
        private void AddLocalClient(ulong id)
        {
            var user = new User(id);
            _clientModel.SetUser(user);
            ApplicationStateMachine.ConnectionStatus = ConnectionStatus.Connected;
        }

        private void CreateGameSession(List<ulong> clients)
        {
          _gameSession.Initialize(clients);
        }

        private void ShowCurrentClients()
        {
            foreach (var client in _clients)
            {
                Debug.Log(client);
            }
        }
    }
}