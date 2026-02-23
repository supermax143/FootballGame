using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Application.Game;
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
      [Inject] GameSessionController _gameSessionController;

      
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

      public override void StartOffline()
      {
         _gameSessionController.Initialize(new List<ulong>());
         _scenesLoader.LoadGameScene();
      }
   }
}