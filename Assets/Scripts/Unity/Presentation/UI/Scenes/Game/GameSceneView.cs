using System;
using Core.Domain.Services.Windows;
using Unity.Game;
using Unity.Infrastructure.Settings;
using Unity.Presentation.UI;
using Unity.Presentation.Windows;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Unity.Presentation
{
    public class GameSceneView : MonoBehaviour
    {
        public event Action OnDisconnectClick;
        public event Action OnShowExampleWindowClick;
        
        [SerializeField]
        private ActiveTeamPanel activeTeamPanel;
        [SerializeField]
        private Image _currenTeamImage; 
        
        [Inject] private IGameModel _gameModel;
        [Inject] private GameSettings _gameSettings;

        private void Start()
        {
            _gameModel.ActivePlayerId.OnValueChanged += OnActivePlayerIdChanged;
        }
       
        public void UpdateView()
        {
            activeTeamPanel.SetActiveTeam((int) _gameModel.ActivePlayerId.Value);
            _currenTeamImage.color = 
                _gameSettings.GetTeamColor(_gameModel.GetLocalPlayerData().TeamIndex);
        }

        private void OnActivePlayerIdChanged(ulong prevId, ulong newId)
        {
            activeTeamPanel.SetActiveTeam((int) newId);
        }

        public void DisconnectClicked()
        {
            OnDisconnectClick?.Invoke();
        }
        
        public void ShowExampleWindowClick()
        {
            OnShowExampleWindowClick?.Invoke();
        }

    }
}