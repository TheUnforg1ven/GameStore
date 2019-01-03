using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Components
{
	/// <summary>
	/// View component for categories menu
	/// </summary>
	public class CategoryMenu : ViewComponent
	{
		/// <summary>
		/// category repository member
		/// </summary>
		private readonly ICategoryRepository _categoryRepository;

		/// <summary>
		/// Initialize member
		/// </summary>
		public CategoryMenu(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		/// <summary>
		/// Invokes list of categories
		/// </summary>
		/// <returns>ordered collection of categories name</returns>
		public IViewComponentResult Invoke()
		{
			// get colletion of categories and order by name
			var caregories = _categoryRepository.Categories.OrderBy(c => c.CategoryName);

			// returns view with categories collection
			return View(caregories);
		}
	}
}
