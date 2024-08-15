namespace Core.Models;

public class Message :BaseEntity
{
    public Guid AuthorId { get; set; }
    public User Author { get; set; }
    public Guid ChatId { get; set; }
    public Chat Chat { get; set; }
    public string Text { get; set; }
}
