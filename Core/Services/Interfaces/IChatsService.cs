using Core.Models.DTOs;
using Core.Models.ViewModels;

namespace Core.Services.Interfaces;

public interface IChatsService
{
    Task<IEnumerable<ChatGetViewModel>> GetUserChatsAsync(Guid userId);
    Task<ChatGetViewModel> GetChatByIdAsync(Guid chatId);
    Task<ChatGetViewModel> AddMessageToChatAsync(SendMessageDTO messageDTO);
}