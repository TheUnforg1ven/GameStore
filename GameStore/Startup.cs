using System;
using GameStore.Data;
using GameStore.Hubs;
using GameStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GameStore
{
	public class Startup
	{
		/// <summary>
		/// Configuration member
		/// </summary>
		private IConfiguration _configuration;

		public Startup(IHostingEnvironment hostingEnvironment)
		{
			_configuration = new ConfigurationBuilder()
				.SetBasePath(hostingEnvironment.ContentRootPath)
				.AddJsonFile("appsettings.json")
				.Build();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			// add Db context with default connection
			services.AddDbContext<ApplicationDbContext>(options => 
			options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

			// add identity context 
			services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders(); // Token provider very important for reseting password!

			// add simple transient services
			services.AddTransient<IGameRepository, GameRepository>();
			services.AddTransient<ICategoryRepository, CategoryRepository>();
			services.AddTransient<IOrderRepository, OrderRepository>();

			// add context services
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped(sp => ShoppingCart.GetCart(sp));

			services.AddSignalR();
			services.AddMvc();
			services.AddMemoryCache();
			services.AddSession();
		}

		public void Configure(IApplicationBuilder app, 
								IHostingEnvironment env, 
								ILoggerFactory loggerFactory, 
								IServiceProvider serviceProvider)
		{
			if (env.IsDevelopment())
			{
				loggerFactory.AddConsole();
				app.UseDeveloperExceptionPage();
				app.UseStatusCodePages();
				app.UseStaticFiles();
				app.UseSession();
				app.UseAuthentication();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			// signalR hub settings
			app.UseSignalR(routes =>
			{
				routes.MapHub<ChatHub>("/chatHub");
			});

			// add all routes
			app.UseMvc(routes => 
			{
				routes.MapRoute(
					name: "Error", 
					template: "Error",
					defaults: new { controller = "Error", action = "Error" }
				);

				routes.MapRoute(
					name: "gameFilter",
					template: "Game/Single/{gameName?}",
					defaults: new { controller = "Game", action = "Single" }
				);

				routes.MapRoute(
					name: "categoryFilter",
					template: "Game/{action}/{category?}",
					defaults: new { controller = "Game", action = "List" }
				);

				routes.MapRoute(
					name: null,
					template: "ShoppingCart",
					defaults: new { controller = "ShoppingCart", action = "Index" });

				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}"
				);
			});

			//SeedData.EnsurePopulated(app);
			//IdentitySeedData.EnsurePopulated(app);
			//SeedRoles.CreateRoles(serviceProvider).Wait();
		}
	}
}
