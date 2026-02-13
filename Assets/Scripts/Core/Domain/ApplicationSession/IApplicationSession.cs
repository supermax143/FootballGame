using System;
using Core.Application.ApplicationSession;

namespace Core.Domain.Services.ApplicationSession
{
   public interface IApplicationSession
   {
      ISessionState CurrentState { get; }
      ConnectionStatus ConnectionStatus { get; }
      event Action<ConnectionStatus> OnConnectionStatusChanged;
      event Action<ISessionState> OnStateChanged;
   }
}