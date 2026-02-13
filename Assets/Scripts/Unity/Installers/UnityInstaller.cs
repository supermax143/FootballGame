using Core.Application.ApplicationSession;
using Core.Application.ApplicationSession.States;
using Core.Application.Localization;
using Unity.Bootstrap.GameInitializer.InitializeSteps;
using Unity.Infrastructure.ResourceManager;
using Unity.Infrastructure.Scenes;
using Unity.Infrastructure.Windows;
using Unity.Netcode;
using UnityEngine;
using Zenject;

namespace Unity.Bootstrap.Installers
{
   internal class UnityInstaller : MonoInstaller
   {

      [SerializeField, HideInInspector]
      private WindowsController _windowsController;
      
      
      private void OnValidate()
      {
         _windowsController = GetComponent<WindowsController>();
      }


      public override void InstallBindings()
      {
         InitializeAddressables();

         Container.BindInterfacesAndSelfTo<ScenesLoader>().AsSingle();
         Container.BindInterfacesAndSelfTo<WindowsController>().FromInstance(_windowsController);
         Container.BindInterfacesAndSelfTo<GameInitializer.GameInitializer>().AsSingle();
         Container.BindInterfacesAndSelfTo<ResourceManager>().AsSingle();
         Container.BindInterfacesAndSelfTo<NetworkManager>().AsSingle();
         Container.BindInstance(NetworkManager.Singleton).AsSingle();
         
         
         
         //Initialization
         Container.Bind<InitializeStepBase>().To<InitLocalizationStep>().AsTransient();
         Container.Bind<InitializeStepBase>().To<LoadAssetsStep>().AsTransient();
      }

      private static void InitializeAddressables()
      {
         var handleStorage = new HandleStorage();
         AsyncOpHandleExtension.Initialize(handleStorage);
         AddressableExtention.Initialize(handleStorage);
      }
      


   }
}