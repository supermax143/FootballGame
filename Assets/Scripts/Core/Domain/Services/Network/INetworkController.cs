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
        void LoadSceneOnClient(ulong clientId, string sceneName);
        bool IsServer { get; }
        bool IsClient { get; }
        bool IsHost { get; }
    }
}