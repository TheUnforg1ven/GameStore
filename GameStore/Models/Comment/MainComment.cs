using System.Collections.Generic;

namespace GameStore.Models.Comment
{
	/// <summary>
	/// Describes main comment
	/// </summary>
	public class MainComment : Comment
	{
		/// <summary>
		/// Collection of subcomments
		/// </summary>
		public List<SubComment> SubComments { get; set; }
	}
}
