using GameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data
{
	/// <summary>
	/// Contains 'Order' entity
	/// </summary>
	public class OrderRepository : IOrderRepository
	{
		/// <summary>
		/// DB context member
		/// </summary>
		private readonly ApplicationDbContext _applicationDbContext;

		/// <summary>
		/// Cart member
		/// </summary>
		private readonly ShoppingCart _shoppingCart;

		/// <summary>
		/// Initialize members
		/// </summary>
		public OrderRepository(ApplicationDbContext applicationDbContext, ShoppingCart shoppingCart)
		{
			_applicationDbContext = applicationDbContext;
			_shoppingCart = shoppingCart;
		}

		/// <summary>
		/// Create order and add into DB
		/// </summary>
		/// <param name="order">order object</param>
		public void CreateOrder(Order order)
		{
			// when order was placed
			order.OrderPlaced = DateTime.Now;

			// add Order entity into DB context
			_applicationDbContext.Orders.Add(order);

			// collection of shopping cart items
			var shoppingCartItems = _shoppingCart.ShoppingCartItems;

			// get each item in shopping cart
			foreach (var item in shoppingCartItems)
			{
				// create order details using 'item' properties
				var orderDetail = new OrderDetail
				{
					Amount = item.Amount,
					GameId = item.Game.GameID,
					OrderId = order.OrderID,
					Price = item.Game.Price
				};

				// add OrderDetails entity into DB context
				_applicationDbContext.OrderDetails.Add(orderDetail);
			}

			// save all changes done with DB context
			_applicationDbContext.SaveChanges();
		}
	}
}
