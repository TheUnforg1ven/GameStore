using GameStore.Models;
using GameStore.Models.Comment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data
{
	/// <summary>
	/// Create DB context
	/// </summary>
	public class ApplicationDbContext : IdentityDbContext<IdentityUser>
	{
		/// <summary>
		/// Initialize context using base ctor
		/// </summary>
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
			:base(options) { }

		/// <summary>
		/// Collection of 'Game' entities
		/// </summary>
		public DbSet<Game> Games { get; set; }

		/// <summary>
		/// Collection of 'Category' entities
		/// </summary>
		public DbSet<Category> Categories { get; set; }

		/// <summary>
		/// Collection of 'ShoppingCartItem' entities
		/// </summary>
		public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

		/// <summary>
		/// Collection of 'Order' entities
		/// </summary>
		public DbSet<Order> Orders { get; set; }

		/// <summary>
		/// Collection of 'OrderDetail' entities
		/// </summary>
		public DbSet<OrderDetail> OrderDetails { get; set; }

		/// <summary>
		/// Collection of 'MainComment' entities
		/// </summary>
		public DbSet<MainComment> MainComments { get; set; }

		/// <summary>
		/// Collection of 'SubComment' entities
		/// </summary>
		public DbSet<SubComment> SubComments { get; set; }
	}
}
