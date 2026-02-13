using Core.Domain.Models;

namespace Core.Application.Models
{
    public interface IClientModel
    {
        User Client { get; }
    }
    
    internal interface IClientModelInternal : IClientModel
    {
        void SetUser(User client);
    }
    
}