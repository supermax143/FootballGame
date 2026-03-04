using Core.Application.ApplicationSession.States;
using Core.Application.Game;
using Core.Application.Localization;
using Zenject;

namespace Core.Application.Installers
{
   public class ApplicationInstaller  : MonoInstaller
   {
      public override void InstallBindings()
      {
          
         Container.BindInterfacesAndSelfTo<LocalizationController>().AsSingle();
         
         // Session
         Container.Bind<InitializeState>().AsTransient();
         Container.Bind<OfflineState>().AsTransient();
         Container.Bind<StartHostingState>().AsTransient();
         Container.Bind<HostingState>().AsTransient();
         Container.Bind<ClientConnectingState>().AsTransient();
         Container.Bind<ClientConnectedState>().AsTransient();
         Container.BindInterfacesAndSelfTo<ApplicationSession.ApplicationStateMachine>().AsSingle().NonLazy();
         
         
         //Server Commands
         
         //GameController
         Container.BindInterfacesAndSelfTo<GameSessionController>().AsSingle();
         
      }
   }
}