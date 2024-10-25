
using BlazorApp.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace BlazorApp.BackgroundServices;

public class MessageBackgroundService : BackgroundService
{
    private readonly IHubContext<MessageHub> _hubContext;

    public MessageBackgroundService(IHubContext<MessageHub> hubContext)
    {
        _hubContext = hubContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000);
            
            Console.WriteLine("Send message");

            // await _hubContext.Clients.All.SendAsync("ReceiveMessage", "Hello World!");

            await _hubContext.Clients.Group("GrupaA").SendAsync("ReceiveMessage", "Hello World!");
        }

    }
}
