namespace Core.Domain.Services.ApplicationSession
{
   public interface ISessionState
   {
      void StartHost();
      void StartClient();
   }
}

