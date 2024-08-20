using AutoMapper;
using Core.Models;
using Core.Models.DTOs;
using Core.Models.ViewModels;
using Core.Repositories.Interfaces;
using Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Services;

public class ChatsService : IChatsService
{
    private readonly IChatsRepository _chatRepository;
    private readonly IUsersService _usersService;
    private readonly IMapper _mapper;

    public ChatsService(IChatsRepository chatRepository, IUsersService usersService, IMapper mapper)
    {
        _chatRepository = chatRepository;
        _usersService = usersService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ChatGetViewModel>> GetUserChatsAsync(Guid userId)
    {
        var chats = await _chatRepository.GetChats()
            .Include(c => c.FirstUser)
            .Include(c => c.SecondUser)
            .Where(c => c.FirstUserId == userId || c.SecondUserId == userId).ToListAsync();
        return _mapper.Map<IEnumerable<Chat>,IEnumerable<ChatGetViewModel>>(chats);
    }

    public async Task<ChatGetViewModel> GetChatByIdAsync(Guid chatId)
    {
        var chat = await _chatRepository.GetChatByIdAsync(chatId);

        if (chat is null)
            throw new Exception();

        return _mapper.Map<Chat, ChatGetViewModel>(chat);
    }


    public async Task<ChatGetViewModel> AddMessageToChatAsync(SendMessageDTO messageDTO)
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
        return _mapper.Map<Chat,ChatGetViewModel>(chat);
    }

    private async Task<Chat> GetChatByUserNames(string firstUserName, string secondUserName)
    {
        var chat = await _chatRepository.GetChats()
            .Include(c => c.Messages)
            .Where(c => c.FirstUser.UserName == firstUserName && c.SecondUser.UserName == secondUserName
            || c.FirstUser.UserName == secondUserName && c.SecondUser.UserName == firstUserName)
            .FirstOrDefaultAsync();

        return chat;
    }
}
