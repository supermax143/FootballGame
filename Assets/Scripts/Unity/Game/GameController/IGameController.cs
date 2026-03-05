using UnityEngine;

namespace Unity.Game
{
    public interface IGameController
    {
        void MakeTurn(ulong clientId, Vector2 force);
    }
}