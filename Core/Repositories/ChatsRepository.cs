using Core.Data;
using Core.Models;
using Core.Repositories.Interfaces;

namespace Core.Repositories;

public class ChatsRepository :IChatsRepository
{
    private readonly ApplicationContext _context;

    public ChatsRepository(ApplicationContext context)
    {
        _context = context;
    }
    public IQueryable<Chat> GetChats()
    {
        return _context.Chats;
    }

    public async Task<Chat> AddMessageToChatAsync(Chat chat, Message message)
    {
        chat.Messages.Add(message);
        await _context.SaveChangesAsync();
        return chat;
    }

    public async Task<Chat> CreateChatAsync(Guid firstUserId, Guid secondUserId)
    {
        var chat = new Chat()
        { 
            FirstUserId = firstUserId,
            SecondUserId = secondUserId   
        };

        _context.Chats.Add(chat);
        await _context.SaveChangesAsync();
        return chat;

    }
}
