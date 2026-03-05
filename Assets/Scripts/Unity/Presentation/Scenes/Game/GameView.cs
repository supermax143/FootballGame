using System;
using Core.Domain.Services.Windows;
using Unity.Game;
using Unity.Presentation.UI;
using Unity.Presentation.Windows;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Unity.Presentation
{
    public class GameView : MonoBehaviour
    {
        public event Action OnDisconnectClick;
        public event Action OnShowExampleWindowClick;
        
        [FormerlySerializedAs("_currentTeamPanel")] [SerializeField]
        private ActiveTeamPanel activeTeamPanel;
        
        [Inject] IGameModel _gameModel;

        private void Start()
        {
            _gameModel.ActivePlayerId.OnValueChanged += OnActivePlayerIdChanged;
            activeTeamPanel.SetActiveTeam((int) _gameModel.ActivePlayerId.Value);
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