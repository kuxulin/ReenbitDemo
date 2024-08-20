namespace Core.Models.ViewModels;

public class ChatGetViewModel
{
    public Guid Id { get; set; }
    public string FirstUserName { get; set; }
    public string SecondUserName { get; set; }
    public IEnumerable<MessageGetViewModel> Messages { get; set; }
}
