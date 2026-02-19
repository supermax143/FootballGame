using Core.Application.ApplicationSession.States;
using Core.Application.Game;
using Core.Application.Localization;
using Core.Application.Models;
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
         
         //Models
         Container.BindInterfacesAndSelfTo<ClientModel>().AsTransient();
         
         //GameController
         Container.BindInterfacesAndSelfTo<GameSessionController>().AsTransient();
         
      }
   }
}