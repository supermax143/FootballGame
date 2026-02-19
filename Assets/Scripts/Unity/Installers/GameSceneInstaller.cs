using Unity.Game;
using UnityEngine;
using Zenject;

namespace Unity.Bootstrap.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        
        [SerializeField]
        private GameSettings _gameSettings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameSettings>().FromInstance(_gameSettings).AsSingle();
        }
        
    }
}