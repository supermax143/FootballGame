using System.Threading.Tasks;

namespace Unity.Bootstrap.GameInitializer.InitializeSteps
{
   internal abstract class InitializeStepBase
   {
      public abstract string Ident { get; }
      
      public abstract Task Execute();
      
   }
}