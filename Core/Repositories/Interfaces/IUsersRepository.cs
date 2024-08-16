using Core.Models;

namespace Core.Repositories.Interfaces;

public interface IUsersRepository
{
    IQueryable<User> GetUsers();
    Task CreateUserAsync(User user);
}
