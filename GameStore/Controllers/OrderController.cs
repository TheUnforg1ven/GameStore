using GameStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
	/// <summary>
	/// All actions with order
	/// </summary>
	public class OrderController : Controller
	{
		/// <summary>
		/// Order repository member
		/// </summary>
		private readonly IOrderRepository _orderRepository;

		/// <summary>
		/// Shopping cart repository member
		/// </summary>
		private readonly ShoppingCart _shoppingCart;

		/// <summary>
		/// Initialize members
		/// </summary>
		public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
		{
			_orderRepository = orderRepository;
			_shoppingCart = shoppingCart;
		}

		/// <summary>
		/// Checkout method
		/// </summary>
		/// <returns>checkout view</returns>
		[Authorize]
		public IActionResult Checkout()
		{
			return View();
		}

		/// <summary>
		/// Make final chakout
		/// </summary>
		/// <param name="order">current order</param>
		/// <returns>view if not ok</returns>
		[HttpPost]
		[Authorize]
		public IActionResult Checkout(Order order)
		{
			// get all items from cart
			var items = _shoppingCart.GetShoppingCartItems();

			// add items into shopping cart
			_shoppingCart.ShoppingCartItems = items;

			// if no items 
			if (_shoppingCart.ShoppingCartItems.Count == 0)
			{
				// add model error
				ModelState.AddModelError("", "Your card is empty, add some games first");
			}

			// if all is ok
			if (ModelState.IsValid)
			{
				// create new order
				_orderRepository.CreateOrder(order);

				// clear user cart
				_shoppingCart.ClearCart();

				// go to complete action
				return RedirectToAction("CheckoutComplete");
			}

			// if error - return same view
			return View(order);
		}

		/// <summary>
		/// Complete method
		/// </summary>
		/// <returns>new view</returns>
		public IActionResult CheckoutComplete()
		{
			// add message and return complete view
			ViewBag.CheckoutCompleteMessage = "Thanks for your order! :)";
			return View();
		}
	}
}
