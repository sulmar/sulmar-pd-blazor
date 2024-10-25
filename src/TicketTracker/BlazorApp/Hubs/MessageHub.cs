using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace BlazorApp.Hubs;

public class MessageHub : Hub
{
    public override Task OnConnectedAsync()
    {

        this.Groups.AddToGroupAsync(this.Context.ConnectionId, "GrupaA");

        return base.OnConnectedAsync();
    }

    
}
