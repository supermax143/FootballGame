using Unity.Game;
using UnityEngine;
using Zenject;

namespace Unity.Bootstrap.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        
        [SerializeField]
        private GameFieldPresenter _gameField;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameSettings>().FromInstance(_gameField).AsSingle();
        }
        
        
        
    }
}