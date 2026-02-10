using Core.Application.ApplicationSession.States;
using Core.Application.Localization;
using Core.Application.Models;
using Core.Application.ServerCommands;
using Zenject;

namespace Core.Application.Installers
{
   public class ApplicationInstaller  : MonoInstaller
   {
      public override void InstallBindings()
      {
          
         Container.BindInterfacesAndSelfTo<LocalizationController>().AsSingle();
         
         // Session
         Container.Bind<InitState>().AsTransient();
         Container.Bind<MainMenuState>().AsTransient();
         Container.Bind<GameState>().AsTransient();
         Container.BindInterfacesAndSelfTo<ApplicationSession.ApplicationStateMachine>().AsSingle().NonLazy();
         
         
         //Server Commands
         Container.Bind<LoginUserCommand>().AsTransient();
         
         //Models
         Container.BindInterfacesAndSelfTo<MainModel>().AsTransient();
         
      }
   }
}