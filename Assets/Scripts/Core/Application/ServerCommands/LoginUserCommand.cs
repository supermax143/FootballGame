using System.Threading.Tasks;
using Core.Application.Models;
using Core.Domain.Models;
using Zenject;

namespace Core.Application.ServerCommands
{
    public class LoginUserCommand
    {

        [Inject] private IMainModelInternal _mainModel;
        
        public async Task Execute()
        {
            var user = new UserModel(12345, "PlayerOne");
            
            _mainModel.SetUser(user);
            await Task.Delay(1000);
        }
    }
}