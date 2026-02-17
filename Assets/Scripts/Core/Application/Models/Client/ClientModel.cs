using Core.Domain.Models;

namespace Core.Application.Models
{
    internal class ClientModel : IClientModelInternal
    {
        public User User { get; private set; }
        
        public void SetUser(User user)
        {
            User = user;
        }
    }
}