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

        private readonly NetworkList<PlayerData> _players = new();
        public NetworkVariable<ulong> ActivePlayerId => _activePlayerId;
        public NetworkList<PlayerData> Players => _players;


        public bool TryGetPlayer(ulong clientId, out PlayerData player)
        {
            player = default;
            foreach (var p in _players)
            {
                if (p.Id == clientId)
                {
                    player = p;
                    return true;
                }
            }
           
            return  false;
        }

        public void Initialize()
        {
            
            if (!IsServer)
            {
                return;
            }
            UpdatePlayersFromSession();
        }
        
        public void SetActivePlayerId(ulong playerId)
        {
            if (!IsServer)
            {
                return;
            }
            _activePlayerId.Value = playerId;
        }

        private void UpdatePlayersFromSession()
        {
            _players.Clear();
            foreach (var player in _gameSession.Players)
            {
                _players.Add(new PlayerData(player.Id, player.PlayerName, player.TeamIndex));
            }
        }
        
    }
}
