using GameStore.Models;

namespace GameStore.ViewModels
{
	/// <summary>
	/// ViewModel for cart
	/// </summary>
	public class ShoppingCartViewModel
	{
		/// <summary>
		/// Current shopping cart
		/// </summary>
		public ShoppingCart ShoppingCart { get; set; }

		/// <summary>
		/// Total value of shopping cart items
		/// </summary>
		public decimal ShoppingCartTotal { get; set; }
	}
}
