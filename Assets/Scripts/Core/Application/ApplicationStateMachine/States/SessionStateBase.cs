using System.Threading.Tasks;
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
      public virtual void ClientConnectedHandler(ulong id, bool local)
      {
         
      }

      public virtual void ClientDisconnectHandler(ulong id, bool local)
      {
      }

      public virtual void Disconnect()
      {
      }

      public virtual void ServerStoppedHandler()
      {
      }


      protected abstract Task OnStateEnter();
      
      protected virtual void OnStateExit() 
      {
      }

   }
}