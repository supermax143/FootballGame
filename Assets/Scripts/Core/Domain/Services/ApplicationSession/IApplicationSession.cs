namespace Core.Domain.Services.ApplicationSession
{
   public interface IApplicationSession
   {
      ISessionState CurrentState { get; }
   }
}