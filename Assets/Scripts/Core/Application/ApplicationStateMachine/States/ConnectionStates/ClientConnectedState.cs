using System.Threading.Tasks;

namespace Core.Application.ApplicationSession.States
{
    internal class ClientConnectedState : SessionStateBase
    {
        protected override Task OnStateEnter()
        {
            ApplicationStateMachine.ConnectionStatus = ConnectionStatus.Connected;
            return Task.CompletedTask;
        }
        
        
        
    }
}