using UnityEngine;

namespace Unity.Game
{
    public class GameSettings : MonoBehaviour
    {
        [SerializeField]
        private Transform[] _spawnPointsTeam1;
        [SerializeField]
        private Transform[] _spawnPointsTeam2;

        public Transform[] SpawnPointsTeam1 => _spawnPointsTeam1;
        public Transform[] SpawnPointsTeam2 => _spawnPointsTeam2;
        
    }
}