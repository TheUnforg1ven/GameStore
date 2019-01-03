using System.Collections.Generic;

namespace GameStore.Models
{
	/// <summary>
	/// Interface with categories for the games
	/// </summary>
	public interface ICategoryRepository
	{
		/// <summary>
		/// Collection consists of 'Category' objects
		/// </summary>
		IEnumerable<Category> Categories { get; }
	}
}
