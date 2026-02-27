using System.Collections.Generic;
using Core.Domain.Models;

namespace Core.Application.Game
{
    public interface IGameSessionController
    {
        IEnumerable<Player> Players { get; }
    }
}