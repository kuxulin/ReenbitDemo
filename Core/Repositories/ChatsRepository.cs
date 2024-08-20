using Core.Data;
using Core.Models;
using Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Chat> GetChatByIdAsync(Guid chatId)
    {
        return await GetChats()
            .Include(c=> c.FirstUser)
            .Include(c=> c.SecondUser)
            .Include(c => c.Messages)
            .Where(c => c.Id == chatId).FirstOrDefaultAsync();
    }

    public async Task<Chat> AddMessageToChatAsync(Chat chat, Message message)
    {
        chat.Messages.Add(message);
        _context.Messages.Add(message);
        _context.Chats.Update(chat);
        await _context.SaveChangesAsync();
        return chat;
    }

    public async Task<Chat> CreateChatAsync(User firstUser, User secondUser)
    {
        var chat = new Chat()
        {
            FirstUser = firstUser,
            SecondUser = secondUser,
            Messages = new List<Message>()
        };

        _context.Chats.Add(chat);
        await _context.SaveChangesAsync();
        return chat;
    }
}
