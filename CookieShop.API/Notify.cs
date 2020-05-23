using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieShop.API
{
    public class Notify : Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("notification", message);
        }

       
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("A client connected" + Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
