using GameStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
	/// <summary>
	/// Login/Register/Reseting password
	/// </summary>
	public class AccountController : Controller
	{
		/// <summary>
		/// UserManager identity member
		/// </summary>
		private readonly UserManager<IdentityUser> _userManager;

		/// <summary>
		/// SignInmanager identity member
		/// </summary>
		private readonly SignInManager<IdentityUser> _signInManager;

		/// <summary>
		/// Initialize context members
		/// </summary>
		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		/// <summary>
		/// When access denied
		/// </summary>
		/// <returns>view</returns>
		public IActionResult AccessDenied() => View();

		/// <summary>
		/// Login view with return url
		/// </summary>
		/// <param name="returnUrl">after logging</param>
		/// <returns>new View with current returnUrl</returns>
		public IActionResult Login(string returnUrl)
		{
			return View(new LoginViewModel
			{
				ReturnUrl = returnUrl
			});
		}

		/// <summary>
		/// Post method to login into web site
		/// </summary>
		/// <param name="loginViewModel">login viewmodel</param>
		/// <returns>same view if error</returns>
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			// if modelstate unvalid - return same view
			if (!ModelState.IsValid)
				return View(loginViewModel);

			//find user
			var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

			// if user exists
			if (user != null)
			{
				// check login and password
				var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

				// all succeeded
				if (result.Succeeded)
				{
					// if empty return url
					if (String.IsNullOrEmpty(loginViewModel.ReturnUrl))
						// go to home page
						return RedirectToAction("Index", "Home");

					// redirect bu return url
					return Redirect(loginViewModel.ReturnUrl);
				}
			}

			// if user not found
			ModelState.AddModelError(String.Empty, "Username or password was not found");

			// same view
			return View(loginViewModel);
		}

		/// <summary>
		/// Register method
		/// </summary>
		/// <returns>Register view</returns>
		public IActionResult Register() => View();

		/// <summary>
		/// ResetPassword method
		/// </summary>
		/// <returns>ResetPassword view</returns>
		public IActionResult ResetPassword() => View();

		/// <summary>
		/// First part of password reseting
		/// </summary>
		/// <param name="username">username who resets password</param>
		/// <returns>redirect to resetlink</returns>
		[HttpPost]
		public IActionResult ResetPassword(string username)
		{
			// find user
			var user = _userManager.FindByNameAsync(username).Result;

			// if there are no suck user
			if (user == null)
			{
				// Return error view with viewbag
				ViewBag.Message = "Error while resetting your password!";
				return View("Error");
			}

			// get reset token async
			var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;

			// create reset link (needs token)
			var resetLink = Url.Action("ResetUserPassword", "Account", new { token }, protocol: HttpContext.Request.Scheme);

			// redirect to reset link
			return Redirect(resetLink); 
		}

		/// <summary>
		/// Reset password method
		/// </summary>
		/// <param name="token">reset link</param>
		/// <returns>ResetUserPassword view</returns>
		public IActionResult ResetUserPassword(string token) => View();

		/// <summary>
		/// Second part of password reseting
		/// </summary>
		/// <param name="resetPassword">creeated reset viewmodel</param>
		/// <returns>same view if not succeed</returns>
		[HttpPost]
		public IActionResult ResetUserPassword(ResetPasswordViewModel resetPassword)
		{
			// find user
			var user = _userManager.FindByNameAsync(resetPassword.UserName).Result;

			// create final reset password structure
			var result = _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password).Result;

			// if all is ok
			if (result.Succeeded)
			{
				// return home view with message
				ViewBag.Message = "Password reset successful!";
				return RedirectToAction("Index", "Home");
			}

			// if not - add model errors
			else
			{
				foreach (var err in result.Errors)
					ModelState.AddModelError("", $"{err.Description}");
			}

			// if error - return same view
			return View(resetPassword);
		}

		/// <summary>
		/// Register post method
		/// </summary>
		/// <param name="loginViewModel">created viewmodel</param>
		/// <returns>same view if not ok</returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(LoginViewModel loginViewModel)
		{
			// if state is valid
			if (ModelState.IsValid)
			{
				// craete new user
				var user = new IdentityUser() { UserName = loginViewModel.UserName };

				// create new account (needs new user)
				var result = await _userManager.CreateAsync(user, loginViewModel.Password);

				// if all is ok
				if (result.Succeeded)
				{
					// go to home page
					return RedirectToAction("Index", "Home");
				}

				// if not
				else
				{
					// add model errors
					foreach (var err in result.Errors)
						ModelState.AddModelError("", $"{err.Description}");
				}

			}

			// same view
			return View(loginViewModel);
		}

		/// <summary>
		/// Logging in
		/// </summary>
		/// <returns>logged view</returns>
		public ViewResult LoggedIn() => View();

		/// <summary>
		/// Logout method
		/// </summary>
		/// <returns>redirect to home page</returns>
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Logout()
		{
			// simple sign out
			await _signInManager.SignOutAsync();

			// go to home page
			return RedirectToAction("Index", "Home");
		}
	}
}
