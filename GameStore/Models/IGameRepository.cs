using GameStore.Models.Comment;
using System.Collections.Generic;

namespace GameStore.Models
{
	/// <summary>
	/// Interface for working with games
	/// </summary>
	public interface IGameRepository
	{
		/// <summary>
		/// Collection consists of 'Game' objects
		/// </summary>
		IEnumerable<Game> Games { get; }

		/// <summary>
		/// Collection consists of 'Game' objects, which are 'preferred' and will be shown on the main page
		/// </summary>
		IEnumerable<Game> PreferredGames { get; }

		/// <summary>
		/// Method to get needed game by gameid
		/// </summary>
		/// <param name="gameId">gameid of needed game</param>
		/// <returns>'Game' object</returns>
		Game GetGameById(int gameId);

		/// <summary>
		/// Method to save new game
		/// </summary>
		/// <param name="game">'Game' for saving</param>
		/// <returns>true if success, false if not</returns>
		bool SaveGame(Game game);

		/// <summary>
		/// Method to save new category
		/// </summary>
		/// <param name="game">'Category' for saving</param>
		/// <returns>true if success, false if not</returns>
		bool SaveCategory(Category category);

		/// <summary>
		/// Method to delete game
		/// </summary>
		/// <param name="gameId">gameid to delete</param>
		/// <returns>Deleted game</returns>
		Game DeleteGame(int gameId);

		/// <summary>
		/// Method to add sub commend under the main comment
		/// </summary>
		/// <param name="comment">'Subcomment' object</param>
		void AddSubComment(SubComment comment);

		/// <summary>
		/// Method to add main comment on the Game page
		/// </summary>
		/// <param name="game">'Game' where to add comment</param>
		void AddMainComment(Game game);
	}
}
