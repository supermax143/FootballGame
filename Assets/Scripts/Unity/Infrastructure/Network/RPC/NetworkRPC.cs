﻿﻿using System.Collections.Generic;
  using Core.Domain.Services;
using Unity.Netcode;
using Zenject;

namespace Unity.Infrastructure.Network.RPC
{
    internal partial class NetworkRPC : NetworkBehaviour
    {
        [Inject] private INetworkObjectSpawnHandler _spawnHandler;
        [Inject] private IScenesLoader _scenesLoader;
        
        private void Start() => DontDestroyOnLoad(gameObject);

        public override void OnNetworkSpawn() => _spawnHandler.RaiseSpawnEvent(this);

        public override void OnNetworkDespawn() => _spawnHandler.RaiseDespawnEvent(this);
        
        private RpcParams ClientParams(ulong clientId, RpcTargetUse use = RpcTargetUse.Temp) 
            => new RpcParams
            {
                Send = new RpcSendParams
                {
                    Target = RpcTarget.Single(clientId, use)
                }
            };
        
        private RpcParams ClientsParams(IEnumerable<ulong> clientIds, RpcTargetUse use = RpcTargetUse.Temp) 
            => new RpcParams
            {
                Send = new RpcSendParams
                {
                    Target = RpcTarget.Group(clientIds, use),
                }
            };
    }
}