using System.Collections.Generic;

namespace GameStore.Models
{
	/// <summary>
	/// Fake repository, while there no database
	/// </summary>
	public class FakeCategoryRepository : ICategoryRepository
	{
		/// <summary>
		/// Creates and returns new List of categories
		/// </summary>
		public IEnumerable<Category> Categories =>
			new List<Category>
			{
				new Category { CategoryName = "Shooter", Description = "Shooter games"},
				new Category { CategoryName = "Action", Description = "Action games"},
				new Category { CategoryName = "Adventure", Description = "Adventure games"},
				new Category { CategoryName = "Sport", Description = "Sport games"},
				new Category { CategoryName = "Fighting", Description = "Fighting games"},
				new Category { CategoryName = "Indie", Description = "Indie games"},
				new Category { CategoryName = "Symulator", Description = "Strategy games"},
				new Category { CategoryName = "Racing", Description = "Racing games"},
				new Category { CategoryName = "Online", Description = "Online games"},
			};
	}
}
