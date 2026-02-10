using Core.Domain.Services;
using Shared.Constants;
using Zenject;

namespace Core.Application.ApplicationSession.States
{
   internal class InitState : SessionStateBase
   {
      [Inject] private IScenesLoader _scenesLoader;
      [Inject] private IGameInitializer _gameInitializer;
      
      protected override async void OnStateEnter()
      {
         if (_scenesLoader.CurScene != SceneNames.InitGameScene)
         {
            await _scenesLoader.LoadInitGameScene();
         }
         await _gameInitializer.Start();
         ApplicationStateMachine.ChangeState<MainMenuState>();
      }
      
   }
}