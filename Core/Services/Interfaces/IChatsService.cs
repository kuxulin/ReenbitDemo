using Core.Models;
using Core.Models.DTOs;
using Core.Models.ViewModels;
using System.Threading.Tasks;

namespace Core.Services.Interfaces;

public interface IChatsService
{
    Task<IEnumerable<ChatGetViewModel>> GetUserChatsAsync(Guid userId);
    Task<ChatGetViewModel> GetChatByIdAsync(Guid chatId);
    Task<ChatGetViewModel> AddMessageToChatAsync(SendMessageDTO messageDTO);
}
