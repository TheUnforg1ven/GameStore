namespace GameStore.Models
{
	/// <summary>
	/// Describes one item from the shopping cart
	/// </summary>
	public class ShoppingCartItem
	{
		/// <summary>
		/// ID of the current shopping cart item
		/// </summary>
		public int ShoppingCartItemID { get; set; }

		/// <summary>
		/// Game in the shopping cart
		/// </summary>
		public Game Game { get; set; }

		/// <summary>
		/// Amount of current game in cart
		/// </summary>
		public int Amount { get; set; }

		/// <summary>
		/// ID of shopping cart consist of this item
		/// </summary>
		public string ShoppingCartID { get; set; }
	}
}
