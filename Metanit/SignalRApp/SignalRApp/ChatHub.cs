using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApp
{
    public class ChatHub:Hub
    {

        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Receive", message, Context.ConnectionId);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Notify", $"{Context.ConnectionId} вошел в чат");
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("Notify", $"{Context.ConnectionId} покинул в чат");
            await base.OnDisconnectedAsync(exception);
        }

    }
}
