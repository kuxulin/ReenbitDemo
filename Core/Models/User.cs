using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Core.Models;
[Index(nameof(UserName))]
public class User :BaseEntity
{
    public string UserName { get; set; }
    public ICollection<Chat>? Chats { get; set; }
}
