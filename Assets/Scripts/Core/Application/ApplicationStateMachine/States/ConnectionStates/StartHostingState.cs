namespace Core.Application.ApplicationSession.States
{
    internal class StartHostingState : SessionStateBase
    {
        protected override void OnStateEnter()
        {
        }

        public override void ServerStartedHandler()
        {
            ApplicationStateMachine.ChangeState<HostingState>();
        }
    }
}