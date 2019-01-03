using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
	/// <summary>
	/// Contact us view page
	/// </summary>
	public class ContactController : Controller
	{
		/// <summary>
		/// Goes to contac us page
		/// </summary>
		/// <returns>Index view</returns>
		public ViewResult Index()
		{
			return View();
		}
	}
}
