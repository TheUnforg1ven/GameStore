using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
	/// <summary>
	/// Online chat using signalr
	/// </summary>
	public class ChatController : Controller
	{
		/// <summary>
		/// Go to needed view
		/// </summary>
		/// <returns>Index view</returns>
		public ViewResult Index() => View();
	}
}
