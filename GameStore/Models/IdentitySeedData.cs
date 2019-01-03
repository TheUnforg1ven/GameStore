using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace GameStore.Models
{
	/// <summary>
	/// Creates Identity Seed Data
	/// </summary>
	public static class IdentitySeedData
	{
		// admin login
		private const string adminUser = "Admin";

		// admin password
		private const string adminPassword = "Secret123$";

		/// <summary>
		/// Adding new "Admin" user
		/// </summary>
		/// <param name="app">variable to create service scope</param>
		public static async void EnsurePopulated(IApplicationBuilder app)
		{
			// creates scope connection
			using (var serviceScope = app.ApplicationServices.CreateScope())
			{
				// uses 'Identity' for creating identity service
				var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

				// identity user variable
				var user = await userManager.FindByIdAsync(adminUser);

				// if there are no such user
				if (user == null)
				{
					// creates new identity user
					user = new IdentityUser("Admin");

					// creates identity structure with login and password
					await userManager.CreateAsync(user, adminPassword);
				}
			}
		}
	}
}
