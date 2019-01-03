using System.ComponentModel.DataAnnotations;

namespace GameStore.ViewModels
{
	/// <summary>
	/// ViewModel for reseting password
	/// </summary>
	public class ResetPasswordViewModel
	{
		/// <summary>
		/// Login (username)
		/// </summary>
		[Required]
		public string UserName { get; set; }

		/// <summary>
		/// New password
		/// </summary>
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		/// <summary>
		/// Confirm new password
		/// </summary>
		[Required]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

		/// <summary>
		/// Token needed for password changing
		/// </summary>
		[Required]
		public string Token { get; set; }
	}
}
