using System.Collections.Generic;

namespace Core.Application.Game
{
    public interface IGameSessionController
    {
        List<ulong> Clients { get; }
    }
}