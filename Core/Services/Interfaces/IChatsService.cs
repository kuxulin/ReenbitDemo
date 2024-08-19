using Core.Models;
using Core.Models.DTOs;
using System.Threading.Tasks;

namespace Core.Services.Interfaces;

public interface IChatsService
{
    Task<IEnumerable<Chat>> GetUserChatsAsync(Guid userId);
    Task<Chat> GetChatByIdAsync(Guid chatId);
    Task<Chat> GetChatByUserNames(string firstUserName, string secondUserName);
    Task<Chat> AddMessageToChatAsync(SendMessageDTO messageDTO);
}
