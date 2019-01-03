using System.ComponentModel.DataAnnotations;

namespace GameStore.ViewModels
{
	/// <summary>
	/// ViewModel for login
	/// </summary>
	public class LoginViewModel
	{
		/// <summary>
		/// Login (username)
		/// </summary>
		[Required]
		[Display(Name = "User Name")]
		public string UserName { get; set; }

		/// <summary>
		/// Needed password
		/// </summary>
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		/// <summary>
		/// Return to this url after logging
		/// </summary>
		public string ReturnUrl { get; set; }
	}
}
