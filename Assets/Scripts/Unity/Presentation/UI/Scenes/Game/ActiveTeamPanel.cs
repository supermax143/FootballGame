using Unity.Infrastructure.Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Unity.Presentation.UI
{
    public class ActiveTeamPanel : MonoBehaviour
    {
        [Inject] private GameSettings _gameSettings;
        
        [SerializeField]
        private Image _teamColorImage;

        public void SetActiveTeam(int value)
        {
            _teamColorImage.color = _gameSettings.GetTeamColor(value);
        }
        
    }
}