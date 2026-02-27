using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Game
{
    [RequireComponent(typeof(GameFieldView))]
    public class GameFieldPresenter : MonoBehaviour
    {
        private GameFieldView _view;

        private void OnValidate()
        {
            _view = GetComponent<GameFieldView>();
        }

        public Transform GameFieldTransform => _view.transform;
        
        public IEnumerable<Transform> GetTeamSpawnPoints(uint index)
        {
            if (index > 1)
                yield break;

            var points = index == 0 
                ? _view.SpawnPointsTeam1 
                : _view.SpawnPointsTeam2;

            foreach (var point in points)
                yield return point;
        }
        
    }
}