using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace GameStore.Hubs
{
	/// <summary>
	/// SognalR chat using hub
	/// </summary>
	[Authorize]
	public class ChatHub : Hub
	{
		/// <summary>
		/// Async send message into chat
		/// </summary>
		/// <param name="user">user name</param>
		/// <param name="message">all message content</param>
		/// <returns>task with sending message</returns>
		public async Task SendMessage(string user, string message)
		{
			// async sending message to all chat users with 'ReceiveMessage' method
			await Clients.All.SendAsync("ReceiveMessage", user, message);
		}
	}
}
