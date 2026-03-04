using System.Collections.Generic;
using Core.Domain.Models;
using Unity.Netcode;

namespace Unity.Game
{
    public interface IGameModel
    {
        NetworkVariable<ulong> ActivePlayerId { get; }
        NetworkList<PlayerData> Players { get; }
        bool TryGetPlayer(ulong clientId, out PlayerData player);
    }
}