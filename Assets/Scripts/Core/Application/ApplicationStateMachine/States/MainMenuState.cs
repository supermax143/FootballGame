using Core.Domain.Services;
using Zenject;

namespace Core.Application.ApplicationSession.States
{
   internal class MainMenuState : SessionStateBase
   {

      [Inject] IScenesLoader _scenesLoader;
      
      protected override void OnStateEnter()
      {
         _scenesLoader.LoadMainMenuScene();
      }

      public override void StartGame() 
      {
         ApplicationStateMachine.ChangeState<GameState>();
      }

   }
}