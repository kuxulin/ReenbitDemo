using Core.Models.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace Core.Hubs;

public class MessageHub :Hub
{
    public async Task SendMessage(SendMessageDTO message)
    {
        Clients.User(message.ToUserId.ToString()).SendAsync("receiveMessage",message.FromUserId, message.ToUserId, message.Text);
    }
}
