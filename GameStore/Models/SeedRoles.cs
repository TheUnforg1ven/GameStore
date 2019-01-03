using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace GameStore.Models
{
	/// <summary>
	/// Creates Identity Seed roles
	/// </summary>
	public class SeedRoles
	{
		/// <summary>
		/// Create all needed roels
		/// </summary>
		/// <param name="serviceProvider"></param>
		/// <returns></returns>
		public static async Task CreateRoles(IServiceProvider serviceProvider)
		{
			// create roleManager service 
			var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			// create userManager servicew
			var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

			// array with roles
			string[] roleNames = { "Admin", "Moderator" };

			// result variable
			IdentityResult roleResult;

			// add roles using RoleManager
			foreach (var roleName in roleNames)
			{
				// check if current role exist
				var roleExist = await RoleManager.RoleExistsAsync(roleName);

				// if not - create new role
				if (!roleExist)
					roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
			}

			// create admin user
			var userAdmin = await UserManager.FindByNameAsync("Admin");

			// if there no 'admin'
			if (userAdmin == null)
			{
				// create new admin
				userAdmin = new IdentityUser()
				{
					UserName = "AdminUser",
					Email = "admin@gmail.com",
				};

				// creates identity structure with login and password
				await UserManager.CreateAsync(userAdmin, "Test@123");
			}

			// add new user into roles
			await UserManager.AddToRoleAsync(userAdmin, "Admin");

			// create moderator user
			var userModerator = await UserManager.FindByNameAsync("Moderator");

			// if there are no moderator
			if (userModerator == null)
			{
				// create new admin moderator
				userModerator = new IdentityUser()
				{
					UserName = "Moderator",
					Email = "moderator@gmail.com",
				};

				// creates identity structure with login and password
				await UserManager.CreateAsync(userModerator, "Moder@123");
			}

			// add moderator into roles
			await UserManager.AddToRoleAsync(userModerator, "Moderator");
		}
	}
}
