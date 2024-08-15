﻿using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Data;

public class ApplicationContext :DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }
}
