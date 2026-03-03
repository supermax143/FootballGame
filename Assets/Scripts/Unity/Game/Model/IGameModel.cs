using Core.Domain.Models;
using Unity.Netcode;

namespace Unity.Game
{
    public interface IGameModel
    {
        NetworkVariable<ulong> ActivePlayerId { get; }
        bool TryGetPlayer(ulong clientId, out Player player);
    }
}