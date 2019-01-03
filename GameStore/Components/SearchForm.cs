using Microsoft.AspNetCore.Mvc;

namespace GameStore.Components
{
	/// <summary>
	/// View component for search
	/// </summary>
	public class SearchForm : ViewComponent
	{
		/// <summary>
		/// Invokes component result for search
		/// </summary>
		/// <returns>new search view</returns>
		public IViewComponentResult Invoke() => View();
	}
}
