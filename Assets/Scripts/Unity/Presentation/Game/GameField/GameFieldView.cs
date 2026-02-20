using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Game
{
    public class GameFieldView : MonoBehaviour
    {
        [SerializeField]
        private Transform[] _spawnPointsTeam1;
        [SerializeField]
        private Transform[] _spawnPointsTeam2;

        public Transform[] SpawnPointsTeam1 => _spawnPointsTeam1;
        public Transform[] SpawnPointsTeam2 => _spawnPointsTeam2;

        private void Start()
        {
            HideSpawnPoints(_spawnPointsTeam1);
            HideSpawnPoints(_spawnPointsTeam2);
        }
        
        private void HideSpawnPoints(IEnumerable<Transform> points)
        {
            foreach (var point in points)
            {
                point.gameObject.SetActive(false);
            }
        }
    }
}