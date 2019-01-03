using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
	/// <summary>
	/// Shaw errors
	/// </summary>
	public class ErrorController : Controller
	{
		/// <summary>
		/// Go to error page
		/// </summary>
		/// <returns>Error view</returns>
		public ViewResult Error() => View();
	}
}
