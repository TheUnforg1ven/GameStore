using GameStore.Models;
using System.Collections.Generic;

namespace GameStore.ViewModels
{
	/// <summary>
	/// ViewModel for games
	/// </summary>
	public class GameListViewModel
	{
		/// <summary>
		/// Collection of games
		/// </summary>
		public IEnumerable<Game> Games { get; set; }

		/// <summary>
		/// Category name, where we can find some games related to this category
		/// </summary>
		public string CurrentCategory { get; set; }
	}
}
