using GameStore.Models;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Components
{
	/// <summary>
	/// View component for shopping cart
	/// </summary>
	public class ShoppingCartSummary : ViewComponent
	{
		/// <summary>
		/// Shopping cart member
		/// </summary>
		private readonly ShoppingCart _shoppingCart;

		/// <summary>
		/// initialize shopping cart member
		/// </summary>
		public ShoppingCartSummary(ShoppingCart shoppingCart)
		{
			_shoppingCart = shoppingCart;
		}

		/// <summary>
		/// Invokes shopping cart at all
		/// </summary>
		/// <returns>new cart with shopping cart view model</returns>
		public IViewComponentResult Invoke()
		{
			// collection of shopping cart items
			var items = _shoppingCart.GetShoppingCartItems();

			// initialize all cart items
			_shoppingCart.ShoppingCartItems = items;

			// create new view model object
			var shoppingCartViewModel = new ShoppingCartViewModel
			{
				// cart object
				ShoppingCart = _shoppingCart,

				// total cart value
				ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
			};

			// returns view with shopping cart viewmodel
			return View(shoppingCartViewModel);
		}
	}
}
