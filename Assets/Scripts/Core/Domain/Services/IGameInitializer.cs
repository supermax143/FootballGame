using System.Threading.Tasks;

namespace Core.Domain.Services
{
   public interface IGameInitializer
   {
      Task Start();
   }
}