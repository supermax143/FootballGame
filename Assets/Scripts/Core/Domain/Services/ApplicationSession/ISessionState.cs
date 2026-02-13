namespace Core.Domain.Services.ApplicationSession
{
   public interface ISessionState
   {
      void StartHost();
      void StartClient();
      void StartServer();
      void ServerStartedHandler();
      void ClientConnectedHandler(ulong id);
      void ClientDisconnectHandler(ulong id);
   }
}

