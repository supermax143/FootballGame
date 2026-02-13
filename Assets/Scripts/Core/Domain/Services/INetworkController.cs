namespace Unity.Infrastructure.Network
{
    public interface INetworkController
    {
        void StartHost();
        void StartClient();
        void StartServer();
    }
}