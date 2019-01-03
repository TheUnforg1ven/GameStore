using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models.Comment
{
	/// <summary>
	/// Describes all comments
	/// </summary>
	public class Comment
	{
		/// <summary>
		/// Comment ID and primary key
		/// </summary>
		[Key]
		public int CommentID { get; set; }

		/// <summary>
		/// Comment message
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Time, when comment was created
		/// </summary>
		public DateTime Created { get; set; }

		/// <summary>
		/// User who created comment
		/// </summary>
		public string UserName { get; set; }
	}
}
