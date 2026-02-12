using Zenject;

namespace Unity.Infrastructure.Network
{
    public class NetworkManager : INetworkManager, IInitializable
    {
        public int ConnectedClientsCount => Netcode.NetworkManager.Singleton.ConnectedClientsList.Count;

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }
        
        public void StartServer()
        {
            Netcode.NetworkManager.Singleton.StartServer();
            
        }
        
        public void StartHost()
        {
            Netcode.NetworkManager.Singleton.StartHost();
        }
        
        public void StartClient()
        {
            Netcode.NetworkManager.Singleton.StartClient();
        }

    }
    
}