using GameStore.Models;
using GameStore.Models.Comment;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data
{
	/// <summary>
	/// Contains 'Game' entity
	/// </summary>
	public class GameRepository : IGameRepository
	{
		/// <summary>
		/// DB context member
		/// </summary>
		private readonly ApplicationDbContext _applicationDbContext;

		/// <summary>
		/// Initialize context member
		/// </summary>
		public GameRepository(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		/// <summary>
		/// Collection of games containing categories
		/// </summary>
		public IEnumerable<Game> Games => _applicationDbContext.Games
											.Include(g => g.Category); // join 'Category' values

		/// <summary>
		/// Collection of preperred games containing categories
		/// </summary>
		public IEnumerable<Game> PreferredGames => _applicationDbContext.Games
														.Where(p => p.IsPreferredGame)
														.Include(g => g.Category); // join 'Category' values

		/// <summary>
		/// Find game by gameID
		/// </summary>
		/// <param name="gameId">ID of needed game</param>
		/// <returns>game if found</returns>
		public Game GetGameById(int gameId) 
			=> _applicationDbContext.Games
									.Include(g => g.Category) // join 'Category' values
									.Include(g => g.MainComments) // join 'MainComments' values
									.ThenInclude(m => m.SubComments) // then join 'SubComments' values
									.FirstOrDefault(g => g.GameID == gameId);

		/// <summary>
		/// Save or Update game entiry
		/// </summary>
		/// <param name="game">game to save</param>
		/// <returns> true if success</returns>
		public async Task<bool> SaveGame(Game game)
		{
			// if there are no such game
			if (game.GameID == 0)
			{
				// find category for new game
				game.Category = _applicationDbContext.Categories.FirstOrDefault(c => c.CategoryName == game.Category.CategoryName);

				// add new game into games Dbset
				_applicationDbContext.Games.Add(game);
			}
			// if there are such a game
			else
			{
				// find it in Dbset
				var dbEntry = _applicationDbContext.Games.FirstOrDefault(g => g.GameID == game.GameID);

				// if it's not null
				if (dbEntry != null)
				{
					// update all game values
					dbEntry.Name = game.Name;
					dbEntry.ShortDescription = game.ShortDescription;
					dbEntry.LongDescription = game.LongDescription;
					dbEntry.Category = _applicationDbContext.Categories.FirstOrDefault(c => c.CategoryName == game.Category.CategoryName);
					dbEntry.Price = game.Price;
					dbEntry.ImageThumbnail = game.ImageThumbnail;
				}
			}

			// save all changes done with DB context
			await _applicationDbContext.SaveChangesAsync();

			// if success
			return true;
		}

		/// <summary>
		/// Add comment on the game page
		/// </summary>
		/// <param name="game">game we need</param>
		public void AddMainComment(Game game)
		{
			// update game 
			_applicationDbContext.Games.Update(game);

			// save all changes done with DB context
			_applicationDbContext.SaveChanges();
		}

		/// <summary>
		/// Save category
		/// </summary>
		/// <param name="category">Category we need</param>
		/// <returns>true if success</returns>
		public bool SaveCategory(Category category)
		{
			// if there are already such category
			if (_applicationDbContext.Categories.Any(c => c.CategoryName == category.CategoryName))
				return false;

			// if there no category
			if (category.CategoryID == 0)
				// add new category into categories Dbset 
				_applicationDbContext.Categories.Add(category);

			// save all changes done with DB context
			_applicationDbContext.SaveChanges();

			// if success
			return true;
		}

		/// <summary>
		/// Delete needed game
		/// </summary>
		/// <param name="gameId">ID of game to delete</param>
		/// <returns>Deleted game</returns>
		public Game DeleteGame(int gameId)
		{
			// find game to delete by gameID
			var dbEntry = _applicationDbContext.Games.FirstOrDefault(p => p.GameID == gameId);

			// if there such game
			if (dbEntry != null)
			{
				// remove founded game
				_applicationDbContext.Games.Remove(dbEntry);

				// save all changes done with DB context
				_applicationDbContext.SaveChanges();
			}

			// copy of deleted game
			return dbEntry;
		}

		/// <summary>
		/// Add subcomment under main comment
		/// </summary>
		/// <param name="comment">subcomment object</param>
		public void AddSubComment(SubComment comment)
		{
			// add new subcomment into SubComments Dbset 
			_applicationDbContext.SubComments.Add(comment);

			// save all changes done with DB context
			_applicationDbContext.SaveChanges();
		}
	}
}
