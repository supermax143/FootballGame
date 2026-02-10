using System.Threading.Tasks;
using Core.Domain.Services;
using Shared.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Unity.Infrastructure.Scenes
{
   internal class ScenesLoader : IScenesLoader  
   {
      [Inject] private ZenjectSceneLoader _sceneLoader;
      
      
      public string CurScene => SceneManager.GetActiveScene().name;


      public async Task  LoadInitGameScene() => await LoadScene(SceneNames.InitGameScene);
      public async Task  LoadMainMenuScene() => await LoadScene(SceneNames.MainMenuScene);
      public async Task  LoadGameScene() => await LoadScene(SceneNames.GameScene);

      private async Task LoadScene(string scene)
      {
         if (CurScene == scene)
         {
            return;
         }
         await _sceneLoader.LoadSceneAsync(scene);
      }
      

   }
}