using GameStore.Models.Comment;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
	/// <summary>
	/// Game model
	/// </summary>
	public class Game
	{
		/// <summary>
		/// ID of current game
		/// </summary>
		public int GameID { get; set; }

		/// <summary>
		/// Game name
		/// </summary>
		[Required(ErrorMessage = "Please enter a game name")]
		public string Name { get; set; }

		/// <summary>
		/// Short description(will be shown in the card)
		/// </summary>
		[Required(ErrorMessage = "Please enter a short description")]
		public string ShortDescription { get; set; }

		/// <summary>
		/// Full game description
		/// </summary>
		public string LongDescription { get; set; }

		/// <summary>
		/// Game price
		/// </summary>
		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
		public decimal Price { get; set; }

		/// <summary>
		/// Image url id
		/// </summary>
		public string ImageUrl { get; set; }

		/// <summary>
		/// Current game image url
		/// </summary>
		[Required(ErrorMessage = "Please enter image url")]
		public string ImageThumbnail { get; set; }

		/// <summary>
		/// Game is preferred or not
		/// </summary>
		public bool IsPreferredGame { get; set; }

		/// <summary>
		/// Game is in stock or not
		/// </summary>
		public bool InStock { get; set; }

		/// <summary>
		/// ID of category game conasist
		/// </summary>
		public int CategoryID { get; set; }

		/// <summary>
		/// Category of the current game
		/// </summary>
		public virtual Category Category { get; set; }

		/// <summary>
		/// Collection of main comments
		/// </summary>
		public List<MainComment> MainComments { get; set; } 
	}
}
