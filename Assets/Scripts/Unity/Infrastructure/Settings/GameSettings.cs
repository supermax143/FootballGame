using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Infrastructure.Settings
{
    [CreateAssetMenu(menuName = "Settings/Game Settings", fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField]
        private Color _team1Color = Color.blue;

        [SerializeField]
        private Color _team2Color = Color.red;

        [SerializeField]
        private AssetReference _playerPrefab;

        public Color Team1Color => _team1Color;
        public Color Team2Color => _team2Color;
        public AssetReference PlayerPrefab => _playerPrefab;
    }
}

