namespace Core.Models;

public class Chat : BaseEntity
{
    public ICollection<Message> Messages { get; set; }
    public Guid FirstUserId { get; set; }
    public User FirstUser { get; set; }
    public Guid SecondUserId { get; set; }
    public User SecondUser { get; set; }
}
