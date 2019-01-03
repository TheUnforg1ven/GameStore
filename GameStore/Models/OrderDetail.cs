namespace GameStore.Models
{
	/// <summary>
	/// Describe detailed order characteristics
	/// </summary>
	public class OrderDetail
	{
		/// <summary>
		/// ID of detail order
		/// </summary>
		public int OrderDetailID { get; set; }

		/// <summary>
		/// ID of the current order
		/// </summary>
		public int OrderId { get; set; }

		/// <summary>
		/// ID of ordered game
		/// </summary>
		public int GameId { get; set; }

		/// <summary>
		/// Amount of game copies in current order
		/// </summary>
		public int Amount { get; set; }

		/// <summary>
		/// Total price of an orderdered game
		/// </summary>
		public decimal Price { get; set; }

		/// <summary>
		/// Current orderred game
		/// </summary>
		public virtual Game Game { get; set; }

		/// <summary>
		/// Current order
		/// </summary>
		public virtual Order Order { get; set; }
	}
}
