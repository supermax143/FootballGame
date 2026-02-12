using Core.Domain.Services;
using Unity.Infrastructure.Network;
using Zenject;

namespace Core.Application.ApplicationSession.States
{
   internal class MainMenuState : SessionStateBase
   {

      [Inject] IScenesLoader _scenesLoader;
      [Inject] INetworkManager _networkManager;
      
      protected override void OnStateEnter()
      {
         _scenesLoader.LoadMainMenuScene();
      }
      
      public override void StartHost() 
      {
         _networkManager.StartHost();
         ApplicationStateMachine.ChangeState<GameState>();
      }

      public override void StartClient()
      {
         _networkManager.StartClient();
      }
   }
}