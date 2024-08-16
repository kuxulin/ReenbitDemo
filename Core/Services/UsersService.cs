using Core.Models;
using Core.Repositories.Interfaces;
using Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Services;

public class UsersService :IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository userRepository)
    {
        _usersRepository = userRepository;
    }

    public async Task<User> GetUserAsync(string username)
    {
        return await _usersRepository.GetUsers()
            .Where(u => u.UserName == username)
            .SingleOrDefaultAsync();
    }

    public async Task<User> CreateUserAsync(string username)
    {
        var possibleDuplicate = await GetUserAsync(username);

        if (possibleDuplicate == null)
        {
            var user = new User() { UserName = username };
            await _usersRepository.CreateUserAsync(user);
            return user;
        }
        
        throw new Exception();
    }
}