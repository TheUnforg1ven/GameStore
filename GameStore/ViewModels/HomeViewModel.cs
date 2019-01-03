using GameStore.Models;
using System.Collections.Generic;

namespace GameStore.ViewModels
{
	/// <summary>
	/// ViewModel of Home page
	/// </summary>
	public class HomeViewModel
	{
		/// <summary>
		/// Collection of the preferred games on the main page (home)
		/// </summary>
		public IEnumerable<Game> PreferredGames { get; set; }
	}
}
