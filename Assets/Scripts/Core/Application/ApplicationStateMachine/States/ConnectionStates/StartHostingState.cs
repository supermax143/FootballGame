using System.Threading.Tasks;

namespace Core.Application.ApplicationSession.States
{
    internal class StartHostingState : SessionStateBase
    {
        protected override Task OnStateEnter()
        {
            ApplicationStateMachine.ConnectionStatus = ConnectionStatus.Connecting;
            return  Task.CompletedTask;
        }

        public override void ServerStartedHandler()
        {
            ApplicationStateMachine.ChangeState<HostingState>();
        }
    }
}