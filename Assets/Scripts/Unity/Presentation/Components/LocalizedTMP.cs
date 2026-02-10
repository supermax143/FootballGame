using Core.Domain.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace Unity.Presentation.Components
{
    [RequireComponent(typeof(TMP_Text))]
    public class LocalizedTMP : MonoBehaviour
    {

        [SerializeField, HideInInspector]
        private TMP_Text _textField;
        [SerializeField]
        private string _key;

        [Inject]
        private ILocalization _localization;

        private void OnValidate()
        {
            _textField = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            if(_textField == null)
            {
                return;
            }
            UpdateText();
            _localization.LanguageChanged += OnLanguageChanged;
        }
        

        private void OnLanguageChanged(string _)
        {
            UpdateText();
        }

        private void UpdateText()
        {
            if (string.IsNullOrEmpty(_key))
                return;

            _textField.text = _localization.Get(_key);
        }

        private void OnDestroy()
        {
            _localization.LanguageChanged -= OnLanguageChanged;
        }

    }
}
