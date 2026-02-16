using System.Threading.Tasks;
using Core.Domain.Services;
using Shared.Constants;
using Unity.Infrastructure.Network;
using Zenject;

namespace Core.Application.ApplicationSession.States
{
   internal class OfflineState : SessionStateBase
   {

      [Inject] IScenesLoader _scenesLoader;
      [Inject] INetworkController _networkController;
      
      protected override async Task OnStateEnter()
      {
         if (_scenesLoader.CurScene != SceneNames.MainMenuScene)
         {
            await _scenesLoader.LoadMainMenuScene();
         }
         ApplicationStateMachine.ConnectionStatus = ConnectionStatus.Offline;
      }
      
      public override void StartHost() 
      {
         ApplicationStateMachine.ChangeState<StartHostingState>();
         _networkController.StartHost();
      }

      public override void StartClient()
      {
         ApplicationStateMachine.ChangeState<ClientConnectingState>();
         _networkController.StartClient();
      }
   }
}