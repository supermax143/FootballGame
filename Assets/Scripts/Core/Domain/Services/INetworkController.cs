namespace Unity.Infrastructure.Network
{
    public interface INetworkController
    {
        void StartHost();
        void StopHost();
        void StartClient();
        void StartServer();
        bool IsLocalClient(ulong clientId);
        void Disconnect();
    }
}