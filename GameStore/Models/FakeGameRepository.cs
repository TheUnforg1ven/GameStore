using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameStore.Models
{
	/// <summary>
	/// Fake repository, while there no database
	/// </summary>
	public class FakeGameRepository //: IGameRepository
	{
		/// <summary>
		/// Category repository member
		/// </summary>
		private readonly ICategoryRepository _categoryRepository = new FakeCategoryRepository();

		/// <summary>
		/// Creates and returns new List of games
		/// </summary>
		public IEnumerable<Game> Games =>
			 new List<Game>
			 {
				 new Game
				 {
					 Name = "Call of Duty Black Ops",
					 Price = 30M,
					 ShortDescription = "Popular call of duty game",
					 LongDescription = "The biggest action series of all time returns. Call of Duty®: Black Ops is an entertainment experience that will take you to conflicts across the globe, as elite Black Ops forces fight in the deniable operations and secret wars that occurred under the veil of the Cold War. ",
					 Category = _categoryRepository.Categories.First(),
					 ImageUrl = "~/Images/GameLogos/Codbo.jpg",
					 InStock = true,
					 IsPreferredGame = true,
					 ImageThumbnail = "https://www.geek.com/wp-content/uploads/2018/02/Call-of-Duty-Black-Ops-4.jpg"
				 },
				 new Game
				 {
					 Name = "Fifa 19",
					 Price = 40M,
					 ShortDescription = "Popular football",
					 LongDescription = "FIFA Ultimate Team™ Draft is an entirely new way to play the beautiful game. Go all out in a string of four single elimination high matches with your team. Achieve four wins in a row to receive the highest reward. Your FIFA Ultimate Team is unique, and now so is the broadcast presentation - tailored specifically to your squad. ",
					 Category = _categoryRepository.Categories.First(),
					 ImageUrl = "~/Images/GameLogos/fifa19.jpg",
					 InStock = true,
					 IsPreferredGame = false,
					 ImageThumbnail = "https://www.footboom.net/img/upload/3/5f924.jpeg"
				 },
				 new Game
				 {
					 Name = "TES Morrowind",
					 Price = 25.5M,
					 ShortDescription = "Popular The Elder Scrolls game",
					 LongDescription = "The game was released for PC on May 1, 2002, in North America and May 2, 2002, in Europe. The Xbox version was released on June 6, 2002, in North America and November 22 in Europe. It is available for the PC and Xbox. It is backward compatible on the Xbox 360. Your FIFA Ultimate Team is unique, and now so is the broadcast presentation - tailored specifically to your squad. ",
					 Category = _categoryRepository.Categories.First(),
					 ImageUrl = "~/Images/GameLogos/morrowind.jpg",
					 InStock = true,
					 IsPreferredGame = false,
					 ImageThumbnail = "https://d31-a.sdn.szn.cz/d_31/d_15102743/img/25/1280x720_honRJ_.jpg"
				 },
				  new Game
				 {
					 Name = "Shadow Tomb Raider",
					 Price = 25.5M,
					 ShortDescription = "Popular game about Lara Croft",
					 LongDescription = "Development began in 2015 following the completion of Rise of the Tomb Raider, lasting until July 2018. Shadow of the Tomb Raider was designed to conclude Lara's journey begun in the 2013 reboot, with a key theme being descent both through the jungle environment and into her personality. The setting and narrative was based on Mayan and Aztec mythologies, consulting historians to design the architecture and people of Paititi. The gameplay was adjusted based on both fan feedback and the wishes of Eidos Montréal, incorporating swimming and grappling while increasing difficulty tailoring. Camilla Luddington returned to provide voice and motion-capture work for Lara.",
					 Category = _categoryRepository.Categories.First(),
					 ImageUrl = "~/Images/GameLogos/shadowtomb.jpg",
					 InStock = true,
					 IsPreferredGame = false,
					 ImageThumbnail =  "https://www.dlcompare.com/upload/cache/game_tetiere/upload/gameimage/file/37645.jpeg"
				 }
			 };

		/// <summary>
		/// Returns Preferred games for user
		/// </summary>
		public IEnumerable<Game> PreferredGames { get; set; }
	}
}
