using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Services.Windows;
using Cysharp.Threading.Tasks;
using Unity.Infrastructure.ResourceManager;
using UnityEngine;
using Zenject;

namespace Unity.Infrastructure.Windows
{
	/// <summary>
	///     Менеджер для управления window'ами.
	///     Обеспечивает, что единовременно может быть открыт только один window.
	///     Window'ы могут находиться на разных сценах.
	/// </summary>
	internal class WindowsController : MonoBehaviour, IWindowsMemberHolder, IWindowsController
    {

        [SerializeField] private Transform _windowsParent;

        [Inject] private readonly DiContainer _diContainer;
        private readonly List<string> _loadingWindows = new();


        private readonly List<WindowsListMember> _windowsList = new();

        

        public event Action<string> OnWindowStartLoading;
        public event Action OnActiveWindowChanged;
        public event Action OnWindowLoadComplete;
        public event Action<string> OnAnyWindowClosed;
        public event Action OnLastWindowClosed;


        void IWindowsMemberHolder.OnWindowRemoved(WindowsListMember member)
        {
            if (!_windowsList.Any())
            {
                Debug.LogError("Calling OnWindowRemoved but windowsList is empty");
                return;
            }

            var isLastMember = _windowsList.Last() == member;

            _windowsList.Remove(member);
            AddressableExtention.ReleaseTag(GetWindowUnloadTag(member.WindowName));

            var isWindowsListEmpty = !_windowsList.Any();
            if (isLastMember)
            {
                OnActiveWindowChanged?.Invoke();
            }

            if (isWindowsListEmpty && !_loadingWindows.Any())
            {
                OnLastWindowClosed?.Invoke();
            }
            
            OnAnyWindowClosed?.Invoke(member.WindowName);
        }
        
        public void ShowWindow<TWindow>(Action<IWindow> handler) where TWindow : IWindow
        {
            ShowWindowInternal<TWindow>(handler).Forget();
        }

        private async UniTask ShowWindowInternal<TWindow>(Action<IWindow> handler) where TWindow : IWindow
        {
            var window = await ShowWindow<TWindow>();
            handler?.Invoke(window);
        }
        
        public async UniTask<IWindow> ShowWindow<TWindow>() where TWindow : IWindow
        {
            var windowType =  typeof(TWindow);
            if (!WindowAttribute.TryGetName(windowType, out var windowName))
            {
                Debug.LogError($"Can't find Window attribute on Type {windowType.Name}");
                return null;
            }
            try
            {
                
                _loadingWindows.Add(windowName);
                OnWindowStartLoading?.Invoke(windowName);

                var windowPrefab = await AddressableExtention.Load<GameObject>(windowName, GetWindowUnloadTag(windowName));
                if (windowPrefab == null)
                {
                    Debug.LogError($"Failed to load window prefab: {windowName}");
                    return null;
                }
                
                return InitializeInstance(windowPrefab, windowName);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception while loading window {windowName}: {ex}");
                return null;
            }
            finally
            {
                _loadingWindows.Remove(windowName);
            }
            
        }

        private IWindow InitializeInstance(GameObject windowPrefab, string windowName)
        {
            var window = _diContainer.InstantiatePrefabForComponent<IWindow>(windowPrefab, _windowsParent);
            var windowsListMember = window.GameObject.AddComponent<WindowsListMember>();
            windowsListMember.Initialize(this, windowName);

            _loadingWindows.Remove(windowsListMember.WindowName);

            ShowWindowInternal(windowsListMember);

            _windowsList.Add(windowsListMember);


            OnWindowLoadComplete?.Invoke();

            return window;
        }

        private void ShowWindowInternal(WindowsListMember member)
        {
            OnActiveWindowChanged?.Invoke();

            var animator = member.GetComponent<Animator>();
            if (animator != null)
                animator.Update(0);

            var rectTransform = member.GetComponent<RectTransform>();
            rectTransform.SetParent(_windowsParent, false);
        }

        private string GetWindowUnloadTag(string windowName) => $"{windowName}-{GetHashCode()}";
    }
}