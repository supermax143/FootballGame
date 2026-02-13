using System.Threading.Tasks;
using Core.Application.Models;
using Core.Domain.Models;
using Zenject;

namespace Core.Application.ServerCommands
{
    public class LoginUserCommand
    {

        [Inject] private IClientModelInternal _clientModel;
        
        public async Task Execute()
        {
            var user = new User(12345);
            
            _clientModel.SetUser(user);
            await Task.Delay(1000);
        }
    }
}