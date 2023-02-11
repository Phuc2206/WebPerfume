using dA.Data.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace dA.Web.Hubs
{
	public class MessageHub : Hub
	{
		public async Task SendMessage(string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", message);
		}
	}
}
