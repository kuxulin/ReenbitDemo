using Microsoft.AspNetCore.SignalR;

namespace Core.Hubs;

public class MessageHub : Hub
{
    public async Task CreateChat(string fromUserName, string toUserName)
    {
        await Clients.Group(fromUserName).SendAsync("newChatCreated");
        await Clients.Group(toUserName).SendAsync("newChatCreated");
    }

    public async Task SendMessage(string fromUserName, string toUserName)
    {
        await Clients.Group(fromUserName).SendAsync("newMessageSent");
        await Clients.Group(toUserName).SendAsync("newMessageSent");
    }

    public async Task LogInHub(string username)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, username);
    }
}
