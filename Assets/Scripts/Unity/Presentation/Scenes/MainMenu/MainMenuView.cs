using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Services;
using Core.Domain.Services.ApplicationSession;
using TMPro;
using UnityEngine;
using Zenject;

namespace Unity.Presentation
{
	public class MainMenuView : MonoBehaviour
	{
		public event Action OnHostClicked;
		public event Action OnClientClicked;
		public event Action<string> OnLanguageChanged;
		
		
		[SerializeField]
		private TMP_Dropdown _languageSelector;

		public void Init(IEnumerable<string> langugeCodes)
		{
			_languageSelector.onValueChanged.AddListener(OnLanguageSelected);
			_languageSelector.options = langugeCodes.
				Select(code => new TMP_Dropdown.OptionData { text = code } ).ToList();
		}
		


		private void OnLanguageSelected(int value) => OnLanguageChanged?.Invoke(_languageSelector.options[value].text);

		public void OnHostClick() => OnHostClicked?.Invoke();

		public void OnClientClick() => OnClientClicked?.Invoke();
	}
}