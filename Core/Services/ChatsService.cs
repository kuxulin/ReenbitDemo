using Core.Models;
using Core.Models.DTOs;
using Core.Repositories.Interfaces;
using Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Services;

public class ChatsService : IChatsService
{
    private readonly IChatsRepository _chatRepository;
    private readonly IUsersService _usersService;

    public ChatsService(IChatsRepository chatRepository, IUsersService usersService)
    {
        _chatRepository = chatRepository;
        _usersService = usersService;
    }

    public async Task<IEnumerable<Chat>> GetUserChatsAsync(Guid userId)
    {
        var chats = await _chatRepository.GetChats()
            .Include(c => c.FirstUser)
            .Include(c => c.SecondUser)
            .Where(c => c.FirstUserId == userId || c.SecondUserId == userId).ToListAsync();
        return chats;
    }

    public async Task<Chat> GetChatByIdAsync(Guid chatId)
    {
        var chat = await _chatRepository.GetChatByIdAsync(chatId);

        if (chat is null)
            throw new Exception();

        return chat;
    }

    public async Task<Chat> GetChatByUserNames(string firstUserName, string secondUserName)
    {
        var chat = await _chatRepository.GetChats()
            .Include(c => c.Messages)
            .Where(c => c.FirstUser.UserName == firstUserName && c.SecondUser.UserName == secondUserName
            || c.FirstUser.UserName == secondUserName && c.SecondUser.UserName == firstUserName)
            .FirstOrDefaultAsync();
        
        return chat;
    }

    public async Task<Chat> AddMessageToChatAsync(SendMessageDTO messageDTO)
    {
        var chat = await GetChatByUserNames(messageDTO.FromUserName, messageDTO.ToUserName);

        var firstUser = await _usersService.GetUserAsync(messageDTO.FromUserName);
        var secondUser = await _usersService.GetUserAsync(messageDTO.ToUserName);

        if (chat is null)
            chat = await _chatRepository.CreateChatAsync(firstUser,secondUser);

        var message = new Message()
        {
            AuthorId = firstUser.Id,
            ChatId = chat.Id,
            Text = messageDTO.Text,
        };

        chat = await _chatRepository.AddMessageToChatAsync(chat, message);
        return chat;
    }
}
