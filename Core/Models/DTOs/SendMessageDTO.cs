namespace Core.Models.DTOs;

public class SendMessageDTO
{
    public string Text { get; set; }
    public Guid FromUserId { get; set; }
    public Guid ToUserId { get; set; }
}
