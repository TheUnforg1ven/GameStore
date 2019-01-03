namespace GameStore.Models.Comment
{
	/// <summary>
	/// Sub comment
	/// </summary>
	public class SubComment : Comment
	{
		/// <summary>
		/// ID of main comment (subcomment relates to the main comment)
		/// </summary>
		public int MainCommentID { get; set; }
	}
}
