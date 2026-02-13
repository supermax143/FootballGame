using Core.Domain.Services;
using Unity.Infrastructure.Network;
using Zenject;

namespace Core.Application.ApplicationSession.States
{
   internal class OfflineState : SessionStateBase
   {

      [Inject] IScenesLoader _scenesLoader;
      [Inject] INetworkController _networkController;
      
      protected override void OnStateEnter()
      {
         _scenesLoader.LoadMainMenuScene();
      }
      
      public override void StartHost() 
      {
         _networkController.StartHost();
         ApplicationStateMachine.ChangeState<GameState>();
      }

      public override void StartClient()
      {
         _networkController.StartClient();
      }
   }
}