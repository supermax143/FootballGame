using System.Threading.Tasks;
using Core.Domain.Services;
using Zenject;

namespace Core.Application.ApplicationSession.States {
	internal class GameState : SessionStateBase
	{
		
		[Inject] IScenesLoader _scenesLoader;
		
		protected override async Task OnStateEnter()
		{
			await _scenesLoader.LoadGameScene();
		}
	}
}