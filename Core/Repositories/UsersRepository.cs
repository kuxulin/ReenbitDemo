using Core.Data;
using Core.Models;
using Core.Repositories.Interfaces;

namespace Core.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ApplicationContext _context;

    public UsersRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public IQueryable<User> GetUsers()
    {
        return _context.Users;
    }
}
