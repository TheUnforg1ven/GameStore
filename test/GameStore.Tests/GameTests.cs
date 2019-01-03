using GameStore.Models;
using Xunit;

namespace GameStore.Tests
{
	public class GameTests
	{
		[Fact]
		public void CanChangeGameName()
		{
			var g = new Game { Name = "TestGame", Price = 125M };

			g.Name = "New game name";

			Assert.Equal("New game name", g.Name);
		}

		[Fact]
		public void CanChangeGamePrice()
		{
			var g = new Game { Name = "TestGame", Price = 125M };

			g.Price = 250M;

			Assert.Equal(250M, g.Price);
		}
	}
}
