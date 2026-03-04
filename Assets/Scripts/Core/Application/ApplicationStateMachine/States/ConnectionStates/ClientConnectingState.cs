using System.Threading.Tasks;
using Core.Domain.Models;
using Unity.Infrastructure.Network;
using Zenject;

namespace Core.Application.ApplicationSession.States
{
    internal class ClientConnectingState : SessionStateBase
    {
        
        [Inject] private INetworkController _networkController;
        
        
        protected override Task OnStateEnter()
        {
            ApplicationStateMachine.ConnectionStatus = ConnectionStatus.Connecting;
            return Task.CompletedTask;
        }

        public override void Disconnect()
        {
            _networkController.Disconnect();
            ApplicationStateMachine.ChangeState<OfflineState>();
        }
        
        public override void ClientConnectedHandler(ulong id, bool local)
        {
            if (!local)
            {
                return;
            }
            
            var user = new User(id);
            ApplicationStateMachine.ChangeState<ClientConnectedState>();
        }
    }
}