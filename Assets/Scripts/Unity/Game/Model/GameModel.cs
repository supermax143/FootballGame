using System.Linq;
using Core.Application.Game;
using Core.Domain.Models;
using Unity.Netcode;
using Zenject;

namespace Unity.Game
{
    public class GameModel : NetworkBehaviour, IGameModel
    {
        [Inject] private IGameSessionController _gameSession;
        
        
        private NetworkVariable<ulong> _activePlayerId = new(
            default, 
            NetworkVariableReadPermission.Everyone, 
            NetworkVariableWritePermission.Server
        );

        public NetworkVariable<ulong> ActivePlayerId => _activePlayerId;


        public bool TryGetPlayer(ulong clientId, out Player player)
        {
            player = _gameSession.Players.FirstOrDefault(p => p.Id == clientId);
            return  player != null;
        }

        public void SetActivePlayerId(ulong playerId)
        {
            if (!IsServer)
            {
                return;
            }
            _activePlayerId.Value = playerId;
        }
        
    }
}