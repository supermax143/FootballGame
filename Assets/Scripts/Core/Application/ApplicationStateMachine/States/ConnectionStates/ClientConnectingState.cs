namespace Core.Application.ApplicationSession.States
{
    internal class ClientConnectingState : SessionStateBase
    {
        protected override void OnStateEnter()
        {
            
        }

        public override void ClientConnectedHandler(ulong id)
        {
            ApplicationStateMachine.ChangeState<ClientConnectedState>();
        }
    }
}