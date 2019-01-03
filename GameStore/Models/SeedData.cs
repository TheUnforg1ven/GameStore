using GameStore.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace GameStore.Models
{
	public static class SeedData
	{
		/// <summary>
		/// Dictionary with category name as a Key and category object as value
		/// </summary>
		private static Dictionary<string, Category> _categories;

		/// <summary>
		/// Create new scope and add initial values into db
		/// </summary>
		/// <param name="app">variable to create service scope</param>
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			// creates scope connection 
			using (var serviceScope = app.ApplicationServices.CreateScope())
			{
				// create new db context
				var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

				// if there are no categories in db
				if (!context.Categories.Any())
					// add new categories - using values from categories dictionary
					context.Categories.AddRange(Categories.Select(c => c.Value));

				// if there are no games in db
				if (!context.Games.Any())
				{
					// add new games
					 context.Games.AddRange(
					 new Game
					 {
						Name = "Call of Duty Black Ops",
						Price = 30M,
						ShortDescription = "Popular call of duty game",
						LongDescription = "The biggest action series of all time returns. Call of Duty®: Black Ops is an entertainment experience that will take you to conflicts across the globe, as elite Black Ops forces fight in the deniable operations and secret wars that occurred under the veil of the Cold War. ",
						Category = Categories["Shooter"],
						ImageUrl = "1",
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
						 Category = Categories["Sport"],
						 ImageUrl = "2",
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
						 Category = Categories["Adventure"],
						 ImageUrl = "3",
						 InStock = true,
						 IsPreferredGame = false,
						 ImageThumbnail = "https://d31-a.sdn.szn.cz/d_31/d_15102743/img/25/1280x720_honRJ_.jpg"
					  },
					  new Game
					  {
						  Name = "Shadow Tomb Raider",
						  Price = 48.5M,
						  ShortDescription = "Popular game about Lara Croft",
						  LongDescription = "Development began in 2015 following the completion of Rise of the Tomb Raider, lasting until July 2018. Shadow of the Tomb Raider was designed to conclude Lara's journey begun in the 2013 reboot, with a key theme being descent both through the jungle environment and into her personality. The setting and narrative was based on Mayan and Aztec mythologies, consulting historians to design the architecture and people of Paititi. The gameplay was adjusted based on both fan feedback and the wishes of Eidos Montréal, incorporating swimming and grappling while increasing difficulty tailoring. Camilla Luddington returned to provide voice and motion-capture work for Lara.",
						  Category = Categories["Action"],
						  ImageUrl = "4",
						  InStock = true,
						  IsPreferredGame = false,
						  ImageThumbnail = "https://www.dlcompare.com/upload/cache/game_tetiere/upload/gameimage/file/37645.jpeg"
					  },
					  new Game
					  {
						  Name = "Witcher 3",
						  Price = 33.5M,
						  ShortDescription = "Popular game about Geralt",
						  LongDescription = "Development began in 2011 and lasted for three and a half years. Voice recording took over two and a half years. The writing was infused with real-life aspects like moral ambiguity in a deliberate attempt to avoid simplification, impart authenticity, and reflect Sapkowski's novels. Europe was the basis of the game's open world, with Poland, Amsterdam, and Scandinavia as its primary inspirations. REDengine 3 enabled the developer to create a complex story without compromising the game world. The music was composed by Marcin Przybyłowicz and performed by the Brandenburg State Orchestra.",
						  Category = Categories["Action"],
						  ImageUrl = "5",
						  InStock = false,
						  IsPreferredGame = false,
						  ImageThumbnail = "https://ksassets.timeincuk.net/wp/uploads/sites/54/2017/08/witcher-3-main-920x518.jpeg"
					  },
					  new Game
					  {
						  Name = "Prey",
						  Price = 60.0M,
						  ShortDescription = "Popular Prey game by arkane studio",
						  LongDescription = "In Prey, the player controls Morgan Yu while exploring the space station Talos I, in orbit around Earth–Moon L2, where research into a hostile alien collective called the Typhon is performed. As the Typhon escape confinement, the player uses a variety of weapons and abilities derived from the Typhon to avoid being killed by the aliens while looking to escape the station. The player gains access to areas of the station by acquiring key items and abilities, eventually allowing the player to fully explore the station in an open world setting.",
						  Category = Categories["Shooter"],
						  ImageUrl = "6",
						  InStock = false,
						  IsPreferredGame = false,
						  ImageThumbnail = "https://steamcdn-a.akamaihd.net/steam/apps/480490/header.jpg?t=1529609383"
					  },
					  new Game
					  {
						  Name = "Destiny 2",
						  Price = 25.8M,
						  ShortDescription = "Popular Activision game",
						  LongDescription = "Ur the most part was also highly praised. Reviews were split on the recategorization of the weapons and the newer activities like the Adventures and Lost Sectors, but praise was unanimous on the exploration of the game world. Changes to PvP were welcomed by some reviewers, though others were critical for the mode lacking player choice. Destiny 2 was nominated for and won various awards, such as at The Game Awards 2017 and Game Critics Awards.",
						  Category = Categories["Shooter"],
						  ImageUrl = "7",
						  InStock = false,
						  IsPreferredGame = false,
						  ImageThumbnail = "https://www.overclockers.ua/news/games/123269-destiny-2.jpg"
					  },
					  new Game
					  {
						  Name = "Red Dead Redemption 2",
						  Price = 55.0M,
						  ShortDescription = "Popular Rockstar",
						  LongDescription = "Red Dead Redemption 2 was released for PlayStation 4 and Xbox One on October 26, 2018. It was universally acclaimed by critics, who praised the story, characters, open world, and considerable level of detail. The game generated $725 million in sales from its opening weekend, ranking behind Rockstar's Grand Theft Auto V as the second most profitable entertainment product launch in history.",
						  Category = Categories["Action"],
						  ImageUrl = "8",
						  InStock = false,
						  IsPreferredGame = false,
						  ImageThumbnail = "https://itc.ua/wp-content/uploads/2018/11/RDR2.jpg"
					  },
					  new Game
					  {
						  Name = "Metro Exodus",
						  Price = 32.8M,
						  ShortDescription = "Popular ukrainian Metro game by 4A games",
						  LongDescription = "Metro Exodus is an upcoming first-person shooter video game developed by the 4A Games and published by Deep Silver. It is the third installment in the Metro video game series based on Dmitry Glukhovsky's novels. It is set to follow the events of Metro 2033 and Metro: Last Light.",
						  Category = Categories["Shooter"],
						  ImageUrl = "9",
						  InStock = false,
						  IsPreferredGame = false,
						  ImageThumbnail = "https://itc.ua/wp-content/uploads/2018/03/Metro-Exodus-Oficial.jpg"
					  });

					// save all changes (all added objects)
					context.SaveChanges();
				}
			}
		}

		/// <summary>
		/// Returns Dictionaty with 'Category Name' as a 'Key' and 'Category object' as a 'Value'
		/// </summary>
		public static Dictionary<string, Category> Categories 
		{
			get
			{
				// if dictionary is null
				if (_categories == null)
				{
					// create new array of categories
					var genresList = new Category[]
					{
						new Category { CategoryName = "Shooter", Description = "Shooter games"},
						new Category { CategoryName = "Action", Description = "Action games"},
						new Category { CategoryName = "Adventure", Description = "Adventure games"},
						new Category { CategoryName = "Sport", Description = "Sport games"},
						new Category { CategoryName = "Fighting", Description = "Fighting games"},
						new Category { CategoryName = "Indie", Description = "Indie games"},
						new Category { CategoryName = "Symulator", Description = "Strategy games"},
						new Category { CategoryName = "Racing", Description = "Racing games"},
						new Category { CategoryName = "Online", Description = "Online games"},
					};

					// initialize dictionary
					_categories = new Dictionary<string, Category>();

					// add keys and values into dictionary
					foreach (var genre in genresList)
					{
						_categories.Add(genre.CategoryName, genre);
					}
				}

				// return filled dictionary
				return _categories;
			}
		}	
	}
}
