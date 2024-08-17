using Core.Models;

namespace Core.Repositories.Interfaces;

public interface IChatsRepository
{
    IQueryable<Chat> GetChats();
    Task<Chat> AddMessageToChatAsync(Chat chat,Message message);
    Task<Chat> CreateChatAsync(Guid firstUserId, Guid secondUserId);
}
