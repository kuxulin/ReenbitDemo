using System.Text.Json;

namespace Core.Models;

public class User :BaseEntity
{
    public string UserName { get; set; }
    public ICollection<Chat>? Chats { get; set; }
}
