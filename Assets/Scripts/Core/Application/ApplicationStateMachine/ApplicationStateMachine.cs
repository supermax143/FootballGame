using System;
using Core.Application.ApplicationSession.States;
using Core.Domain.Services.ApplicationSession;
using Zenject;

namespace Core.Application.ApplicationSession
{
   internal class ApplicationStateMachine : IApplicationSession, IInitializable
   {

      public event Action<ConnectionStatus> OnConnectionStatusChanged; 
      
      public event Action<ISessionState> OnStateChanged;
      
      [Inject] private DiContainer _container;

      private ISessionStateInternal _currentState;
      private ConnectionStatus _connectionStatus = ConnectionStatus.Offline;

      public ISessionState CurrentState => _currentState;

      public ConnectionStatus ConnectionStatus
      {
         get => _connectionStatus;
         internal set
         {
            if (value == _connectionStatus)
            {
               return;
            }
            _connectionStatus = value;
            OnConnectionStatusChanged?.Invoke(_connectionStatus);
         }
      }

      public void Initialize()
      {
         ChangeState<InitState>();
      }

      internal void ChangeState<TState>() where TState : ISessionStateInternal
      {
         var newState = _container.Resolve<TState>();
         ChangeState(newState);
      }
      
      private void ChangeState(ISessionStateInternal newState)
      {
         if (_currentState != null)
         {
            _currentState.Exit();
         }
            
         _currentState = newState;
         _currentState.Enter();
            
         OnStateChanged?.Invoke(_currentState);
      }

     
   }
}