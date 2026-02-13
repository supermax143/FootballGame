using Core.Application.ApplicationSession;
using Core.Application.ApplicationSession.States;
using Core.Application.Localization;
using Unity.Bootstrap.GameInitializer.InitializeSteps;
using Unity.Infrastructure.Network;
using Unity.Infrastructure.ResourceManager;
using Unity.Infrastructure.Scenes;
using Unity.Infrastructure.Windows;
using Unity.Netcode;
using UnityEngine;
using Zenject;

namespace Unity.Bootstrap.Installers
{
   [RequireComponent(typeof(WindowsController), typeof(NetworkManager))]
   internal class UnityInstaller : MonoInstaller
   {

      [SerializeField, HideInInspector]
      private WindowsController _windowsController;
      [SerializeField, HideInInspector]
      private NetworkManager _networkManager;
      
      
      private void OnValidate()
      {
         _windowsController = GetComponent<WindowsController>();
         _networkManager = GetComponent<NetworkManager>();
      }


      public override void InstallBindings()
      {
         InitializeAddressables();

         Container.BindInterfacesAndSelfTo<ScenesLoader>().AsSingle();
         Container.BindInterfacesAndSelfTo<WindowsController>().FromInstance(_windowsController);
         Container.BindInterfacesAndSelfTo<GameInitializer.GameInitializer>().AsSingle();
         Container.BindInterfacesAndSelfTo<ResourceManager>().AsSingle();
         Container.BindInstance(_networkManager).AsSingle().NonLazy();
         Container.BindInterfacesAndSelfTo<NetworkController>().AsSingle();
         
         
         
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