using Core.Domain.Models;

namespace Core.Application.Models
{
    public interface IClientModel
    {
        User User { get; }
    }
    
    internal interface IClientModelInternal : IClientModel
    {
        void SetUser(User user);
    }
    
}