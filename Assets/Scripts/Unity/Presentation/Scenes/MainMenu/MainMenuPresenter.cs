using System;
using Core.Application.ApplicationSession;
using Core.Domain.Services;
using Core.Domain.Services.ApplicationSession;
using UnityEngine;
using Zenject;

namespace Unity.Presentation
{
    public class MainMenuPresenter : MonoBehaviour
    {
        
        [SerializeField, HideInInspector]
        private MainMenuView _view;
       
        [Inject] private IApplicationSession _applicationSession;
        [Inject] private ILocalization _localization;
        
        private void OnValidate()
        {
            _view = GetComponent<MainMenuView>();
        }

        private void Start()
        {
            _view.OnClientClicked += ClientClickedHandler;
            _view.OnHostClicked += HostClickedHandler;
            _view.OnLanguageChanged += LanguageChangedHandler;
            _view.OnDisconnectClicked += DisconnectClickedHandler;
            _applicationSession.OnConnectionStatusChanged += ConnectionStatusChangedHandler;
            
            if (!_localization.TryGetLanguageCodes(out var langugeCodes))
            {
                langugeCodes = Array.Empty<string>();
            }

            _view.Init(langugeCodes, _applicationSession.ConnectionStatus);
        }


        private void ConnectionStatusChangedHandler(ConnectionStatus connectionStatus)
        {
            _view.UpdateButtons(connectionStatus);
        }

        private void LanguageChangedHandler(string languageCode)
            => _localization.SetLanguage(languageCode);

        private void HostClickedHandler() 
            => _applicationSession.CurrentState.StartHost();

        private void ClientClickedHandler()
            => _applicationSession.CurrentState.StartClient();
        private void DisconnectClickedHandler()
        {
            _applicationSession.CurrentState.Disconnect();
        }

        private void OnDestroy()
        {
            _view.OnClientClicked -= ClientClickedHandler;
            _view.OnHostClicked -= HostClickedHandler;
            _view.OnLanguageChanged -= LanguageChangedHandler;
            _applicationSession.OnConnectionStatusChanged -= ConnectionStatusChangedHandler;
        }
    }
}