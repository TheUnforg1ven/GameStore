using GameStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
	/// <summary>
	/// All admin functions
	/// </summary>
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		/// <summary>
		/// Game repository member
		/// </summary>
		private readonly IGameRepository _gameRepository;

		/// <summary>
		/// Initialize members
		/// </summary>
		public AdminController(IGameRepository gameRepository)
		{
			_gameRepository = gameRepository;
		}

		/// <summary>
		/// Show all games
		/// </summary>
		/// <returns>View with collection of games</returns>
		public ViewResult Index() => View(_gameRepository.Games);

		/// <summary>
		/// Find game to edit and make all changes
		/// </summary>
		/// <param name="gameId">gameID of game to edit</param>
		/// <returns>Edition view</returns>
		public ViewResult Edit(int gameId) =>
			View(_gameRepository.Games.FirstOrDefault(g => g.GameID == gameId));

		/// <summary>
		/// Edit current game
		/// </summary>
		/// <param name="game">game to edit</param>
		/// <returns>Needed view</returns>
		[HttpPost]
		public async Task<IActionResult> Edit(Game game)
		{
			// if model is ok
			if (ModelState.IsValid)
			{
				// save result
				var savingResult = await _gameRepository.SaveGame(game);

				// if all is ok - go to Index page
				if (savingResult)
				{
					TempData["message"] = $"{game.Name} has been saved";
					return RedirectToAction("Index");
				}

				// go to index with error message
				else
				{
					TempData["message"] = $"{game.Name} wasn't saved. You already have such game!";
					return RedirectToAction("Index");
				}
			}
			// if model wrong - return same view
			else
			{
				return View(game);
			}
		}

		/// <summary>
		/// Create new category , add al values
		/// </summary>
		/// <returns>category view</returns>
		public ViewResult CreateCategory() => View();

		/// <summary>
		/// Creation category
		/// </summary>
		/// <param name="category"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult CreateCategory(Category category)
		{
			// if model is ok
			if (ModelState.IsValid)
			{
				// save current category
				var savingResult = _gameRepository.SaveCategory(category);

				// if all is ok - go to Index page
				if (savingResult)
				{
					TempData["message"] = $"{category.CategoryName} has been saved";
					return RedirectToAction("Index");
				}

				// go to Index page with error
				else
				{
					TempData["message"] = $"{category.CategoryName} wasn't saved. You already have such category!";
					return RedirectToAction("Index");
				}
					
			}
			// add all available errors
			else
			{
				var modelStateErrors = ModelState.Keys.SelectMany(key => ModelState[key].Errors);
				return View(category);
			}
		}

		/// <summary>
		/// Go to edit view with new Game object
		/// </summary>
		/// <returns>View with object of new game to add</returns>
		public ViewResult Create() => View("Edit", new Game());

		/// <summary>
		/// Deleted game by id
		/// </summary>
		/// <param name="gameId">Id of game to delete</param>
		/// <returns>redirect to action</returns>
		[HttpPost]
		public IActionResult Delete(int gameId)
		{
			// variable of deleted game
			var deletedGame = _gameRepository.DeleteGame(gameId);

			// if all is ok - show deleted game name
			if (deletedGame != null)
			{
				TempData["message"] = $"{deletedGame.Name} was deleted";
			}

			// redirect to index page
			return RedirectToAction("Index");
		}
	}
}
