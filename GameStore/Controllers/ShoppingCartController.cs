using GameStore.Models;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GameStore.Controllers
{
	public class ShoppingCartController : Controller
	{
		/// <summary>
		/// Game repository member
		/// </summary>
		private readonly IGameRepository _gameRepository;

		/// <summary>
		/// Shopping cart repository member
		/// </summary>
		private readonly ShoppingCart _shoppingCart;

		/// <summary>
		/// Initialize members
		/// </summary>
		public ShoppingCartController(IGameRepository gameRepository, ShoppingCart shoppingCart)
		{
			_gameRepository = gameRepository;
			_shoppingCart = shoppingCart;
		}

		/// <summary>
		/// main cart index page
		/// </summary>
		/// <returns>view with viewmodel</returns>
		public ViewResult Index()
		{
			// get items from shopping cart
			var items = _shoppingCart.GetShoppingCartItems();

			// put items into cart property
			_shoppingCart.ShoppingCartItems = items;

			// create new view model
			var shoppingCartViewModel = new ShoppingCartViewModel
			{
				// shopping cart object
				ShoppingCart = _shoppingCart,

				// total cart value
				ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
			};

			// return view with created viewmodel
			return View(shoppingCartViewModel);
		}

		/// <summary>
		/// Add game to shopping cart
		/// </summary>
		/// <param name="gameId">gameID of game to add</param>
		/// <returns>view Index</returns>
		public RedirectToActionResult AddToShoppingCart(int gameId)
		{
			// find game in db context
			var selectedGame = _gameRepository.Games.FirstOrDefault(p => p.GameID == gameId);

			// if such game exists
			if (selectedGame != null)
				// add item to cart
				_shoppingCart.AddToCart(selectedGame, 1);

			// go to index view
			return RedirectToAction("Index");
		}

		/// <summary>
		/// Remove item from shopping cart
		/// </summary>
		/// <param name="gameId">gameID of game to remove</param>
		/// <returns>new Index view</returns>
		public RedirectToActionResult RemoveFromShoppingCart(int gameId)
		{
			// find selected game
			var selectedGame = _gameRepository.Games.FirstOrDefault(p => p.GameID == gameId);

			// if such game exists
			if (selectedGame != null)
				// remove it
				_shoppingCart.RemoveFromCart(selectedGame);

			// go to index view
			return RedirectToAction("Index");
		}
	}
}
