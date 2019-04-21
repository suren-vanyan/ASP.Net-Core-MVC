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
            await this.Clients.All.SendAsync("Send", message);
        }

    }
}
