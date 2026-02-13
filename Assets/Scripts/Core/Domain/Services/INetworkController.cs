namespace Unity.Infrastructure.Network
{
    public interface INetworkController
    {
        void StartHost();
        void StartClient();
        void StartServer();
        ulong LocalClientId { get; }
        bool IsLocalClient(ulong clientId);
    }
}