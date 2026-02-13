using System.Collections.Generic;
using UnityEngine;

namespace Core.Application.ApplicationSession.States
{
    internal class HostingState : SessionStateBase
    {
        
        private List<ulong> _clients = new();
        
        protected override void OnStateEnter()
        {
            
        }

        public override void ClientConnectedHandler(ulong id)
        {
            if (_clients.Contains(id))
            {
                return;
            }
            _clients.Add(id);
            Debug.Log("ClientConnected:");
            ShowCurrentClients();
        }

        public override void ClientDisconnectHandler(ulong id)
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