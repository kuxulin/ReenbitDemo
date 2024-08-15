namespace Core.Models;

public class Chat : BaseEntity
{
    public ICollection<Message> Messages { get; set; }
    public ICollection<User> Users { get; set; }
}
