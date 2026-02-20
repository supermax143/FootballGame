using Unity.Game;
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
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameFieldPresenter>().FromInstance(_gameField).AsSingle();
            Container.BindInterfacesAndSelfTo<GameSettings>().FromInstance(_gameSettings).AsSingle();
        }
        
        
        
    }
}