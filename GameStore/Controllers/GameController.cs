using GameStore.Models;
using GameStore.Models.Comment;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameStore.Controllers
{
	/// <summary>
	/// Main controller for game objects
	/// </summary>
	public class GameController : Controller
	{
		/// <summary>
		/// Category repository member
		/// </summary>
		private readonly ICategoryRepository _categoryRepository;
		
		/// <summary>
		/// Game repository member
		/// </summary>
		private readonly IGameRepository _gameRepository;

		/// <summary>
		/// Initialize members
		/// </summary>
		public GameController(ICategoryRepository categoryRepository, IGameRepository gameRepository)
		{
			_categoryRepository = categoryRepository;
			_gameRepository = gameRepository;
		}

		/// <summary>
		/// Show game list for needed category
		/// </summary>
		/// <param name="category">game category name</param>
		/// <returns>new games viewmodel</returns>
		public ViewResult List(string category)
		{
			// game collection
			IEnumerable<Game> games;

			// new local category var
			var currentCategory = string.Empty;

			// if category name exists
			if (!string.IsNullOrEmpty(category)) 
			{
				// get game list
				games = _gameRepository.Games.Where(g => g.Category.CategoryName.Equals(category, StringComparison.OrdinalIgnoreCase));
			}
			// get all available games
			else
			{
				// order by ID
				games = _gameRepository.Games.OrderBy(g => g.GameID);
				currentCategory = "All games";
			}

			// update curcategory value
			currentCategory = category;

			// return new view model with all needed game values
			return View(new GameListViewModel
			{
				Games = games,
				CurrentCategory = currentCategory
			});
		}

		/// <summary>
		/// Show single game
		/// </summary>
		/// <param name="gameName">needed game name</param>
		/// <returns>view with game</returns>
		public ViewResult Single(string gameName)
		{
			Game game;

			// find game
			var commentGame = _gameRepository.Games.FirstOrDefault(g => g.Name.Equals(gameName, StringComparison.OrdinalIgnoreCase));

			// if game exists
			if (!string.IsNullOrEmpty(gameName))
				// get game by id
				game = _gameRepository.GetGameById(commentGame.GameID);
			else
				// create new game object
				game = new Game();

			// if there are no main comments
			if (game.MainComments == null)
				// create new list of comments
				game.MainComments = new List<MainComment>();

			// return view with single game
			return View(game);
		}

		/// <summary>
		/// Search for game by name
		/// </summary>
		/// <param name="searchString">string to search</param>
		/// <returns>view with games</returns>
		public ViewResult Search(string searchString)
		{
			// string needed to find
			var neededString = searchString ?? "  ";

			// find games by needed string
			var games = _gameRepository.Games.Where(g => g.Name.Contains(neededString, StringComparison.OrdinalIgnoreCase));

			// return view of finded games
			return View(new GameListViewModel
			{
				Games = games,
				CurrentCategory = searchString
			});
		}

		/// <summary>
		/// Leave comment under game
		/// </summary>
		/// <param name="commentVM">created comment vm</param>
		/// <returns>same view with new comment</returns>
		[HttpPost]
		[Authorize]
		public IActionResult Comment(CommentViewModel commentVM)
		{
			// find game by gameID
			var game = _gameRepository.GetGameById(commentVM.GameID);

			// if model is not valid
			if (!ModelState.IsValid)
				// redirect to same page
				return RedirectToAction(game.Name, "Game/Single");

			// if it is no main comment
			if(commentVM.MainCommentID == 0)
			{
				// create comments collection
				game.MainComments = game.MainComments ?? new List<MainComment>();

				// add new main comment into collection
				game.MainComments.Add(new MainComment
				{
					Message = commentVM.Message,
					UserName = commentVM.UserName,
					Created = DateTime.Now
				});

				// add main comment into context
				_gameRepository.AddMainComment(game);

				//var comments = _gameRepository.Games.FirstOrDefault(g => g.Name == game.Name).MainComments;
			}

			// if maincommentID !=0 -> so we leave sub comment under main comment
			else
			{
				// create new sub comment
				var comment = new SubComment
				{
					MainCommentID = commentVM.MainCommentID,
					Message = commentVM.Message,
					UserName = commentVM.UserName,
					Created = DateTime.Now
				};

				// add sub comment into context
				_gameRepository.AddSubComment(comment);
			}

			// redirect to the same page
			return RedirectToAction("Single", new { gameName = game.Name});
		}
	}
}
