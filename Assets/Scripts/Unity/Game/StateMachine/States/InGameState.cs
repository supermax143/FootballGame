using System;
using System.Linq;
using Zenject;
using Random = UnityEngine.Random;

namespace Unity.Game
{
    internal class InGameState : GameStateBase
    {
        
        protected override void OnStateEnter()
        {
            var playerId = _gameSession.Players
                .ToArray()[Random.Range(0, _gameSession.Players.Count())].Id;
            _gameModel.SetActivePlayerId(playerId);
        }
    }
}