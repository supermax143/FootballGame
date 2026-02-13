using System.Collections.Generic;
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
        
        private List<ulong> _clients = new();
        
        protected override void OnStateEnter()
        {
            
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
            
            Debug.Log("ClientConnected:");
            ShowCurrentClients();
        }

        private void AddLocalClient(ulong id)
        {
            var user = new User(id);
            _clientModel.SetUser(user);
            ApplicationStateMachine.ConnectionStatus = ConnectionStatus.Connected;
        }
        
        public override void ClientDisconnectHandler(ulong id, bool local)
        {
            if (!_clients.Contains(id))
            {
                return;
            }
            _clients.Remove(id);
            Debug.Log("ClientDisconnect:");
            ShowCurrentClients();
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