using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GameStore.ApiControllers
{
	/// <summary>
	/// Api controller to get info using http
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class InformationController : Controller
	{
		/// <summary>
		/// gameRepository member
		/// </summary>
		private IGameRepository _gameRepository;

		/// <summary>
		/// categoryRepository member
		/// </summary>
		private ICategoryRepository _categoryRepository;

		/// <summary>
		/// Initialize repository members
		/// </summary>
		public InformationController(IGameRepository gameRepository, ICategoryRepository categoryRepository)
		{
			_gameRepository = gameRepository;
			_categoryRepository = categoryRepository;
		}

		/// <summary>
		/// Get collection of all games
		/// </summary>
		/// <returns>game collection</returns>
		[HttpGet("games")]
		public IEnumerable<Game> GetGame() => _gameRepository.Games;

		/// <summary>
		/// Get needed game by gameID
		/// </summary>
		/// <param name="id">id of game</param>
		/// <returns>founded game</returns>
		[HttpGet("games/{id}")]
		public Game GetGame(int id) => _gameRepository.GetGameById(id);

		/// <summary>
		/// Get collection of all categories
		/// </summary>
		/// <returns>categories collection</returns>
		[HttpGet("categories")]
		public IEnumerable<Category> GetCategory() => _categoryRepository.Categories;

		/// <summary>
		/// Get needed collection by collectionID
		/// </summary>
		/// <param name="id">id of needed collection</param>
		/// <returns>founded collection</returns>
		[HttpGet("categories/{id}")]
		public Category GetCategory(int id) => _categoryRepository.Categories.FirstOrDefault(c => c.CategoryID == id);
	}
}
