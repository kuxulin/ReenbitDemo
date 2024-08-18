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
        var chats = await _chatRepository.GetChats().Where(c => c.FirstUserId == userId || c.SecondUserId == userId).ToListAsync();
        return chats;
    }

    public async Task<Chat> GetChatByIdAsync(Guid chatId)
    {
        var chat = await _chatRepository.GetChats().Where(c => c.Id == chatId).FirstOrDefaultAsync();

        if (chat is null)
            throw new Exception();

        return chat;
    }

    public async Task<Chat> GetChatByUserIds(Guid firstUserId, Guid secondUserId)
    {
        var firstUserTask = _usersService.GetUserByIdAsync(firstUserId);
        var secondUserTask = _usersService.GetUserByIdAsync(secondUserId);

        await Task.WhenAll(firstUserTask, secondUserTask);

        if(firstUserTask.Result is null ||  secondUserTask.Result is null)
            throw new Exception("One or both users don`t exist");

        return await _chatRepository.GetChats().Where(c => c.FirstUserId == firstUserId && c.SecondUserId == secondUserId
            || c.FirstUserId == secondUserId && c.SecondUserId == firstUserId)
            .FirstOrDefaultAsync();
    }

    public async Task<Chat> AddMessageToChatAsync(SendMessageDTO messageDTO)
    {
        var chat = await GetChatByUserIds(messageDTO.FromUserId, messageDTO.ToUserId);

        if (chat is null)
            chat = await _chatRepository.CreateChatAsync(messageDTO.FromUserId, messageDTO.ToUserId);

        var message = new Message()
        {
            AuthorId = messageDTO.FromUserId,
            ChatId = chat.Id,
            Text = messageDTO.Text,
        };

        chat = await _chatRepository.AddMessageToChatAsync(chat, message);
        return chat;
    }
}
