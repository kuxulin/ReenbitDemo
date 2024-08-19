using Core.Models;

namespace Core.Repositories.Interfaces;

public interface IChatsRepository
{
    IQueryable<Chat> GetChats();
    Task<Chat> GetChatByIdAsync(Guid chatId);
    Task<Chat> AddMessageToChatAsync(Chat chat,Message message);
    Task<Chat> CreateChatAsync(User firstUser, User secondUser);
}
