using Unity.Netcode;
using Zenject;

namespace Unity.Game
{
    public class GameController : NetworkBehaviour, IGameController
    {
        [Inject] private IGameModel _gameModel;
        
        
        
        
    }
}