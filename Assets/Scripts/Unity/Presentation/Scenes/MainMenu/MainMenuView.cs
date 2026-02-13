using System;
using System.Collections.Generic;
using System.Linq;
using Core.Application.ApplicationSession;
using Core.Domain.Services;
using Core.Domain.Services.ApplicationSession;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Unity.Presentation
{
	public class MainMenuView : MonoBehaviour
	{
		
		public event Action OnHostClicked;
		public event Action OnClientClicked;
		public event Action OnDisconnectClicked;
		
		public event Action<string> OnLanguageChanged;
		
		[SerializeField]
		private TMP_Dropdown _languageSelector;
		[SerializeField]
		private Button _buttonHost;
		[SerializeField]
		private Button _buttonClient;
		[SerializeField]
		private Button _buttonDisconnect;

		public void Init(IEnumerable<string> languageCodes, ConnectionStatus connectionStatus)
		{
			_languageSelector.onValueChanged.AddListener(OnLanguageSelected);
			_languageSelector.options = languageCodes.
				Select(code => new TMP_Dropdown.OptionData { text = code } ).ToList();

			UpdateButtons(connectionStatus);
		}

		public void UpdateButtons(ConnectionStatus connectionStatus)
		{
			var showConnection = connectionStatus == ConnectionStatus.Offline;
			var showDisconnection = connectionStatus is 
				ConnectionStatus.Connected or ConnectionStatus.Connecting;
			
			_buttonHost.gameObject.SetActive(showConnection);
			_buttonClient.gameObject.SetActive(showConnection);
			_buttonDisconnect.gameObject.SetActive(showDisconnection);
		}


		private void OnLanguageSelected(int value) => OnLanguageChanged?.Invoke(_languageSelector.options[value].text);

		public void OnHostClick() => OnHostClicked?.Invoke();
		public void OnClientClick() => OnClientClicked?.Invoke();
		public void OnDisconnectClick() => OnDisconnectClicked?.Invoke();
	}
}