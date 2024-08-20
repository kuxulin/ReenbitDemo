using Core.Models.DTOs;
using Core.Models.ViewModels;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatsController : ControllerBase
{
    private readonly IChatsService _chatsService;

    public ChatsController(IChatsService chatsService)
    {
        _chatsService = chatsService;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<ChatGetViewModel>> GetUserChatsAsync(Guid userId)
    {
        var chats = await _chatsService.GetUserChatsAsync(userId);
        return Ok(chats);
    }

    [HttpGet]
    public async Task<ActionResult<ChatGetViewModel>> GetChatDataAsync(Guid chatId)
    {
        var chat = await _chatsService.GetChatByIdAsync(chatId);
        return Ok(chat);
    }

    [HttpPut]
    public async Task<ActionResult<ChatGetViewModel>> AddMessageToChatAsync(SendMessageDTO sendMessage)
    {
        var chat = await _chatsService.AddMessageToChatAsync(sendMessage);
        return Ok(chat);
    }
}
