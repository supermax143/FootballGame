using System.Threading.Tasks;

namespace Core.Domain.Services
{
   public interface IScenesLoader
   {
      Task  LoadInitGameScene();
      Task  LoadMainMenuScene();
      Task  LoadGameScene();
      string CurScene { get; }
      Task LoadScene(string sceneName);
   }
}