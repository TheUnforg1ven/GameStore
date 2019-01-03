using GameStore.Models;
using System.Collections.Generic;

namespace GameStore.Data
{
	/// <summary>
	/// Contain 'Category' entity
	/// </summary>
	public class CategoryRepository : ICategoryRepository
	{
		/// <summary>
		/// DB context member
		/// </summary>
		private readonly ApplicationDbContext _applicationDbContext;

		/// <summary>
		/// Initialize context member
		/// </summary>
		public CategoryRepository(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		/// <summary>
		/// Collection of categories
		/// </summary>
		public IEnumerable<Category> Categories => _applicationDbContext.Categories;
	}
}
