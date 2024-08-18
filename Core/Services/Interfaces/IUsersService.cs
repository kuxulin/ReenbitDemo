﻿using Core.Models;

namespace Core.Services.Interfaces;

public interface IUsersService
{
    Task<User> GetUserAsync(string username);
    Task<User> GetUserByIdAsync(Guid id);
    Task<User> CreateUserAsync(string username);
}
