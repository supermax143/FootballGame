using Unity.Netcode;

namespace Unity.Infrastructure.Network
{
    public interface INetworkObjectSpawnHandler
    {
        void RaiseSpawnEvent(NetworkBehaviour behaviour);
        void RaiseDespawnEvent(NetworkBehaviour behaviour);
    }
}