using Core.Domain.Models;
using Unity.Netcode;

namespace Unity.Game
{
    public class GameModel : NetworkBehaviour
    {
        private NetworkList<Player>
        
        private NetworkVariable<ulong> _activePlayerId = new(
            default, 
            NetworkVariableReadPermission.Everyone, 
            NetworkVariableWritePermission.Server
        );

        
        public void Initialize()
        {
            
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