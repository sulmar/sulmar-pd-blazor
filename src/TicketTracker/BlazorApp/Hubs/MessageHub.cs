using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace BlazorApp.Hubs;


public class MessageHub : Hub
{
    public override Task OnConnectedAsync()
    {
        var groups = Context.User.Claims.Where(c => c.Type == "Group").Select(c=>c.Value);

        foreach (var group in groups)
        {
            this.Groups.AddToGroupAsync(this.Context.ConnectionId, group);
        }

        return base.OnConnectedAsync();
    }

    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }

    
}
