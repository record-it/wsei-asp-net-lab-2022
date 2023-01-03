using Microsoft.AspNetCore.SignalR;

namespace lab_9.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("message", user, message);
    }

    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
        
    }
    
    
}