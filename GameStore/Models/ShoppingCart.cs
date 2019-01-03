using GameStore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameStore.Models
{
	public class ShoppingCart
	{
		/// <summary>
		/// DB context member
		/// </summary>
		private readonly ApplicationDbContext _applicationDbContext;

		/// <summary>
		/// Initialize db context
		/// </summary>
		public ShoppingCart(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		/// <summary>
		/// ID of current shopping cart
		/// </summary>
		public string ShoppingCartID { get; set; }

		/// <summary>
		/// Collection of shopping cart items
		/// </summary>
		public List<ShoppingCartItem> ShoppingCartItems { get; set; }

		/// <summary>
		/// Create and return new shopping cart object
		/// </summary>
		/// <param name="services">provider for service creation</param>
		/// <returns>new shopping cart object</returns>
		public static ShoppingCart GetCart(IServiceProvider services)
		{
			// create session using 'IHttpContextAccessor'
			var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

			// create DB context
			var context = services.GetService<ApplicationDbContext>();

			// get cartID or if there no cart - create new cartID using Guid
			var cartId = session.GetString("CartID") ?? Guid.NewGuid().ToString();

			// set cartID in current session
			session.SetString("CartID", cartId);

			// returns new shopping cart object with initialized cardID
			return new ShoppingCart(context) { ShoppingCartID = cartId };
		}

		/// <summary>
		/// Add game to cart
		/// </summary>
		/// <param name="game">Game to add</param>
		/// <param name="amount">amopunt of game copies</param>
		public void AddToCart(Game game, int amount)
		{
			// search in DB context for needed game in shopping cart
			var shoppingCartItem = _applicationDbContext.ShoppingCartItems
							.SingleOrDefault(s => s.Game.GameID == game.GameID && s.ShoppingCartID == ShoppingCartID);

			// if there no needed game in shoppnig cart
			if (shoppingCartItem == null)
			{
				// create new shopping cart object
				shoppingCartItem = new ShoppingCartItem
				{
					ShoppingCartID = ShoppingCartID,
					Game = game,
					Amount = amount
				};

				// add created shopping cart object into DB context
				_applicationDbContext.ShoppingCartItems.Add(shoppingCartItem);
			}

			// in the other way - increment the amount of current game in cart
			else
				shoppingCartItem.Amount += amount;

			// save all changes done with DB context
			_applicationDbContext.SaveChanges();
		}

		/// <summary>
		/// Remove game from cart
		/// </summary>
		/// <param name="game">game to remove</param>
		/// <returns>new amount of game copies in cart</returns>
		public int RemoveFromCart(Game game)
		{
			// search in DB context for needed game in shopping cart
			var shoppingCartItem = _applicationDbContext.ShoppingCartItems
				.SingleOrDefault(s => s.Game.GameID == game.GameID && s.ShoppingCartID == ShoppingCartID);

			// initialize local amount var
			var localAmount = 0;

			//  if we found needed cart item
			if (shoppingCartItem != null)
			{
				// if there at least 2 copies of game in shopping cart
				if (shoppingCartItem.Amount > 1)
				{
					// decrement amount of copies by 1
					shoppingCartItem.Amount--;
					
					// write new value in local var
					localAmount = shoppingCartItem.Amount;
				}
				else
				{
					// if there only 1 copy - remove item from 'ShoppingCartItems'
					_applicationDbContext.ShoppingCartItems.Remove(shoppingCartItem);
				}
			}

			// save all changes done with DB context
			_applicationDbContext.SaveChanges();

			// returns new amount of game copies
			return localAmount;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>Collection of cart items</returns>
		public List<ShoppingCartItem> GetShoppingCartItems()
		{
			// return list of items if it not null
			//in the other way - get list of shopping cart items from DB context
			return ShoppingCartItems ??
				   (ShoppingCartItems = _applicationDbContext.ShoppingCartItems
							.Where(c => c.ShoppingCartID == ShoppingCartID)
							.Include(s => s.Game)
							.ToList());
		}

		/// <summary>
		/// Just clear cart
		/// </summary>
		public void ClearCart()
		{
			// get all items from DB context of cart with needed ID
			var cartItems = _applicationDbContext
				.ShoppingCartItems
				.Where(cart => cart.ShoppingCartID == ShoppingCartID);

			// remove all needed items
			_applicationDbContext.ShoppingCartItems.RemoveRange(cartItems);

			// save all changes done with DB context
			_applicationDbContext.SaveChanges();
		}

		/// <summary>
		/// Get total cart value
		/// </summary>
		/// <returns>total value</returns>
		public decimal GetShoppingCartTotal()
		{
			// get all needed items by ID
			// count total by multiplying amount of game copies and Price of game copy
			// summ them in the end
			var total = _applicationDbContext.ShoppingCartItems
					.Where(c => c.ShoppingCartID == ShoppingCartID)
					.Select(c => c.Game.Price * c.Amount)
					.Sum();

			// return counted value
			return total;
		}
	}
}
