namespace GameStore.Models
{
	/// <summary>
	/// Interface with methods for working with orders
	/// </summary>
	public interface IOrderRepository
	{
		/// <summary>
		/// Method for creating an order
		/// </summary>
		/// <param name="order">'Order' object</param>
		void CreateOrder(Order order);
	}
}
