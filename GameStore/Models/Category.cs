using System.Collections.Generic;

namespace GameStore.Models
{
	/// <summary>
	/// Category model
	/// </summary>
	public class Category
	{
		/// <summary>
		/// ID of current category, the primary key
		/// </summary>
		public int CategoryID { get; set; }

		/// <summary>
		/// Name of the current category
		/// </summary>
		public string CategoryName { get; set; }

		/// <summary>
		/// Description for the category
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Collection of Games
		/// One to many relation: 1 category -> many games
		/// </summary>
		public List<Game> Games { get; set; }
	}
}
