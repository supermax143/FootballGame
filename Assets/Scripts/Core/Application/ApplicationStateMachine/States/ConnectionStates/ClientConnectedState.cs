using System.Threading.Tasks;
using Unity.Infrastructure.Network;
using Zenject;

namespace Core.Application.ApplicationSession.States
{
    internal class ClientConnectedState : SessionStateBase
    {

        [Inject] private INetworkController _networkController;

        protected override Task OnStateEnter()
        {
            ApplicationStateMachine.ConnectionStatus = ConnectionStatus.Connected;
            return Task.CompletedTask;
        }

        public override void Disconnect()
        {
            _networkController.Disconnect();
        }

        public override void ClientDisconnectHandler(ulong id, bool local)
        {
            if (!local)
            {
                return;
            }

            ApplicationStateMachine.ChangeState<OfflineState>();
        }

    }
}