using Core.Domain.Models;
using UnityEngine;
using Unity.Netcode;

namespace Unity.Game
{
    /// <summary>
    /// Presenter component for Player.
    /// Coordinates between the domain model and the view.
    /// </summary>
    [RequireComponent(typeof(PlayerView))]
    [RequireComponent(typeof(NetworkObject))]
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        private PlayerView _view;

        [SerializeField]
        private Color _team1Color = Color.blue;

        [SerializeField]
        private Color _team2Color = Color.red;

        private Player _playerModel;

        private void OnValidate()
        {
            _view = GetComponent<PlayerView>();
        }

        public void Initialize(Player player)
        {
            _playerModel = player;
            UpdateView();
        }

       
        private void UpdateView()
        {
            if (_playerModel == null || _view == null)
                return;

            // Set color based on team
            Color teamColor = _playerModel.PlayerTeam == Player.Team.Team1 
                ? _team1Color 
                : _team2Color;

            _view.SetSpriteColor(teamColor);
        }

        public void SetCustomColor(Color color)
        {
            _view?.SetSpriteColor(color);
        }

        public Player GetPlayerModel()
        {
            return _playerModel;
        }
    }
}

