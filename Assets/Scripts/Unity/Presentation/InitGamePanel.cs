using Core.Domain.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Unity.Presentation
{
    public class InitGamePanel : MonoBehaviour
    {
    
        [SerializeField]
        private TMP_Text _textField;
        [SerializeField]
        private Scrollbar _scrollbar;
    
        [Inject] IInitializeProgress _initializeProgress;
        [Inject] ILocalization _localization;
    
        void Start()
        {
            _initializeProgress.OnInitStepStarted += UpdateView;
            _initializeProgress.OnInitializationComplete += UpdateView;
            UpdateView();
        }

        private void UpdateView()
        {
            _scrollbar.size = _initializeProgress.Progress;
            if (_localization.Initialized)
            {
                _textField.text = _localization.Get(_initializeProgress.CurStepIdent);
            }
        }


        private void OnDestroy()
        {
            _initializeProgress.OnInitStepStarted -= UpdateView;
            _initializeProgress.OnInitializationComplete -= UpdateView;
        }
    }
}
