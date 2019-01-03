using GameStore.Models;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
	/// <summary>
	/// Main controller
	/// </summary>
	public class HomeController : Controller
	{
		/// <summary>
		/// Game repository member
		/// </summary>
		private readonly IGameRepository _gameRepository;

		/// <summary>
		/// Initialize members
		/// </summary>
		public HomeController(IGameRepository gameRepository)
		{
			_gameRepository = gameRepository;
		}

		/// <summary>
		/// Return view with preffered games
		/// </summary>
		/// <returns>new view with viewmodel</returns>
		public ViewResult Index()
		{
			// create new view model with pref games
			var homeViewModel = new HomeViewModel
			{
				PreferredGames = _gameRepository.PreferredGames
			};

			// return view with created viewmodel
			return View(homeViewModel);
		}
	}
}
