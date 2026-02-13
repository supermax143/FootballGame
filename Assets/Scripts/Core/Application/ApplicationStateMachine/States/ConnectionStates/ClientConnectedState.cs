namespace Core.Application.ApplicationSession.States
{
    internal class ClientConnectedState : SessionStateBase
    {
        protected override void OnStateEnter()
        {
            ApplicationStateMachine.ConnectionStatus = ConnectionStatus.Connected;
        }
        
        
        
    }
}