using CookieShop.Domain.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookieShop.API
{
    public class Notify : Hub
    {

        public static ConcurrentDictionary<string, List<string>> ConnectedUsers = new ConcurrentDictionary<string, List<string>>();

            
        public async Task Send(string message)
        {
            
            await Clients.All.SendAsync("notification", message);
        }

        public async Task SendToUser(string userId, string message)
        {
            if (ConnectedUsers.TryGetValue(userId, out var dicVal) && dicVal!=null)
            {
                await Clients.Clients(dicVal).SendAsync("notification", message);
                // "tester" key exists and contains "testing" value
            }
           
        }

        public override Task OnConnectedAsync()
        {
            //"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
            var userId = Context.User?.Claims?.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
            // var userName = Context.User.Identity.Name; // or get it from Context.User.Identity.Name;
            if (userId != null && userId != string.Empty)
            {
                // Try to get a List of existing user connections from the cache
                List<string> existingUserConnectionIds;
                ConnectedUsers.TryGetValue(userId, out existingUserConnectionIds);

                // happens on the very first connection from the user
                if (existingUserConnectionIds == null)
                {
                    existingUserConnectionIds = new List<string>();
                }

                // First add to a List of existing user connections (i.e. multiple web browser tabs)
                existingUserConnectionIds.Add(Context.ConnectionId);


                // Add to the global dictionary of connected users
                ConnectedUsers.TryAdd(userId, existingUserConnectionIds);

                return base.OnConnectedAsync();
            }
            return null;
        }

        public override Task OnDisconnectedAsync(Exception stopCalled)
        {
            var userName = Context.User?.Claims?.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userName != null && userName != string.Empty)
            {
                List<string> existingUserConnectionIds;
                ConnectedUsers.TryGetValue(userName, out existingUserConnectionIds);

                // remove the connection id from the List 
                if (existingUserConnectionIds != null && existingUserConnectionIds.Contains(Context.ConnectionId))
                {
                    existingUserConnectionIds.Remove(Context.ConnectionId);
                }

                // If there are no connection ids in the List, delete the user from the global cache (ConnectedUsers).
                if (existingUserConnectionIds.Count == 0)
                {
                    // if there are no connections for the user,
                    // just delete the userName key from the ConnectedUsers concurent dictionary
                    //List<string> garbage; // to be collected by the Garbage Collector
                    ConnectedUsers.TryRemove(userName, out _);
                }

                return base.OnDisconnectedAsync(stopCalled);
            }
            return null;
        }
        //public override Task OnConnectedAsync()
        //{
        //    Console.WriteLine("A client connected" + Context.ConnectionId);
        //    return base.OnConnectedAsync();
        //}
    }
}
