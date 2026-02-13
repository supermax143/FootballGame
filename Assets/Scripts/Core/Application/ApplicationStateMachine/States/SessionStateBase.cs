using Core.Domain.Services.ApplicationSession;
using Zenject;

namespace Core.Application.ApplicationSession.States
{
   internal abstract class SessionStateBase : ISessionStateInternal
   {
      
      [Inject] protected ApplicationStateMachine ApplicationStateMachine;

      public void Enter()
      {
         OnStateEnter();
      }

      public void Exit()
      {
         OnStateExit();
      }

      public virtual void StartHost() { }
      public virtual void StartClient() { }
      public virtual void StartServer() { }
      public virtual void ServerStartedHandler() { }
      public virtual void ClientConnectedHandler(ulong id)
      {
      }

      public virtual void ClientDisconnectHandler(ulong id)
      {
      }


      protected abstract void OnStateEnter();
      
      protected virtual void OnStateExit() 
      {
      }

   }
}