using System;

namespace Core.Domain.Services
{
   public interface IInitializeProgress
   {
      event Action OnInitializationComplete;
      string CurStepIdent { get; }
      float Progress { get; }
      event Action OnInitStepStarted;
   }
}