using Unity.Netcode;
using Zenject;

namespace Unity.Game
{
    internal class InitializeGameState : GameStateBase
    {
        [Inject] private GameSettings _gameSettings;
        
        protected override void OnStateEnter()
        {
            foreach (var spawn in _gameSettings.SpawnPointsTeam1)
            {
                spawn.GetComponent<NetworkObject>().Despawn();
            }
            foreach (var spawn in _gameSettings.SpawnPointsTeam2)
            {
                spawn.gameObject.SetActive(false);
            }
        }
    }
}