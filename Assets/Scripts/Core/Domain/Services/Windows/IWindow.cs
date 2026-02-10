using System;
using UnityEngine;

namespace Core.Domain.Services.Windows
{

	public interface IWindow
	{
		GameObject GameObject { get; }
		void Show();

		void Hide();
		event Action<IWindow> OnShow;
		event Action<IWindow> OnHide;
	}
}