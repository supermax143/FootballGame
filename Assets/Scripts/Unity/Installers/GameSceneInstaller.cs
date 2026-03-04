using Environments.Land.Scripts.Runtime.Controllers.Touch;
using Environments.Land.Scripts.Runtime.Controllers.Touch.Handlers;
using Unity.Game;
using Unity.Infrastructure.Camera;
using Unity.Infrastructure.Settings;
using UnityEngine;
using Zenject;

namespace Unity.Bootstrap.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        
        [SerializeField]
        private GameFieldPresenter _gameField;
        [SerializeField]
        private GameSettings _gameSettings;
        [SerializeField]
        private TouchController _touchController;
        [SerializeField]
        private CameraController _cameraController;
        [SerializeField]
        private GameModel _gameModel;
        [SerializeField]
        private GameController _gameController;
        
        
        [SerializeField]
        private GameStateManager _gameStateManager;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameSettings>().FromInstance(_gameSettings).AsSingle();
            Container.BindInterfacesAndSelfTo<TouchController>().FromInstance(_touchController).AsSingle();
            Container.BindInterfacesAndSelfTo<CameraController>().FromInstance(_cameraController).AsSingle();
            Container.BindInterfacesAndSelfTo<GameModel>().FromInstance(_gameModel).AsSingle();
            Container.BindInterfacesAndSelfTo<GameStateManager>().FromInstance(_gameStateManager).AsSingle();
            Container.BindInterfacesAndSelfTo<GameController>().FromInstance(_gameController).AsSingle();
            Container.BindInterfacesAndSelfTo<GameFieldPresenter>().FromInstance(_gameField).AsSingle();
            
            
            Container.BindInterfacesAndSelfTo<FieldTouchHandler>().AsSingle();
            
        }
        
        
        
    }
}