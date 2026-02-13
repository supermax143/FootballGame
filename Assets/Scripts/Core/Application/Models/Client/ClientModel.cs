using Core.Domain.Models;

namespace Core.Application.Models
{
    internal class ClientModel : IClientModelInternal
    {
        public User Client { get; private set; }
        
        public void SetUser(User client)
        {
            Client = client;
        }
    }
}