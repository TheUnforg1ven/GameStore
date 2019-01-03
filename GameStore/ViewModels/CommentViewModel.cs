using System.ComponentModel.DataAnnotations;

namespace GameStore.ViewModels
{
	/// <summary>
	/// ViewModel to show comment
	/// </summary>
	public class CommentViewModel
	{
		/// <summary>
		/// GameID of game (which comment related to)
		/// </summary>
		[Required]
		public int GameID { get; set; }

		/// <summary>
		/// ID of main comment
		/// </summary>
		[Required]
		public int MainCommentID { get; set; }

		/// <summary>
		/// Full comment message
		/// </summary>
		[Required]
		public string Message { get; set; }
		
		/// <summary>
		/// User who left comment
		/// </summary>
		[Required]
		public string UserName { get; set; }
	}
}
