using System.Threading.Tasks;

namespace Unity.Bootstrap.GameInitializer.InitializeSteps
{
   internal class LoadAssetsStep : InitializeStepBase
   {
      public override string Ident => "load_assets";
      
      public override async Task Execute()
      {
         await Task.Delay(1000);//TODO: заглушка
      }
   }
}