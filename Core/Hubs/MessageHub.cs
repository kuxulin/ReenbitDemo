using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace Core.Hubs;

public class MessageHub : Hub
{
    private static ConcurrentDictionary<string,string> _connectionIds = new();

    public async Task CreateChat(string fromUserName, string toUserName)
    {
        _connectionIds.TryGetValue(fromUserName, out string fromUserId);
        _connectionIds.TryGetValue(toUserName, out string toUserid);
        await Clients.Users(fromUserId, toUserid).SendAsync("newChatCreated");
    }

    public async Task SendMessage(string fromUserName, string toUserName)
    {
        _connectionIds.TryGetValue(fromUserName, out string fromUserId);
        _connectionIds.TryGetValue(toUserName, out string toUserid);
        await Clients.Users(fromUserId, toUserid).SendAsync("newMessageSent");
    }

    public async Task LogInHub(string username)
    {
        var id = Context.ConnectionId;
        _connectionIds.TryAdd(username, id);
    }
}
