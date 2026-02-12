namespace Unity.Infrastructure.Network
{
    public interface INetworkManager
    {
        void StartHost();
        void StartClient();
    }
}