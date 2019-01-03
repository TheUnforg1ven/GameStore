using GameStore.Controllers;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GameStore.Tests
{
	public class HomeControllerTests
	{
		[Fact]
		public void IndexActionModelIsComplete()
		{
			// Arrange
			var mock = new Mock<IGameRepository>();
			mock.Setup(rep => rep.Games).Returns(GetTestGames());

			var controller = new HomeController(mock.Object);

			// Act
			var result = controller.Index();

			// Assert
			Assert.Equal(GetTestGames(), result.Model);
		}

		private List<Game> GetTestGames()
		{
			var games = new List<Game>
			{
				new Game { GameID = 1, Name="Game 1", Price = 925.5M },
				new Game { GameID = 2, Name="Game 2", Price = 344.5M },
				new Game { GameID = 3, Name="Game 3", Price = 450M },
				new Game { GameID = 4, Name="Game 4", Price = 235M },
			};

			return games;
		}
	}
}
