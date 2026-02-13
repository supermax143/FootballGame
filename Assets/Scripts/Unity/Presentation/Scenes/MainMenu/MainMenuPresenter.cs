using System;
using Core.Domain.Services;
using Core.Domain.Services.ApplicationSession;
using Cysharp.Threading.Tasks.Triggers;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace Unity.Presentation
{
    [RequireComponent(typeof(MainMenuView))]
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
            
            if (!_localization.TryGetLanguageCodes(out var langugeCodes))
            {
                langugeCodes = Array.Empty<string>();
            }

            _view.Init(langugeCodes);
        }
        
        private void LanguageChangedHandler(string languageCode)
            => _localization.SetLanguage(languageCode);

        private void HostClickedHandler() 
            => _applicationSession.CurrentState.StartHost();

        private void ClientClickedHandler()
            => _applicationSession.CurrentState.StartClient();
    }
}