using System.Threading.Tasks;
using Core.Application.ServerCommands;
using Zenject;

namespace Unity.Bootstrap.GameInitializer.InitializeSteps
{
   internal class LoginStep : InitializeStepBase
   {
      [Inject] private DiContainer _container;
      
      public override string Ident => "login_state";
      
      public override async Task Execute()
      {
         var loginCommand = _container.Resolve<LoginUserCommand>();
         await loginCommand.Execute();
      }
   }
}