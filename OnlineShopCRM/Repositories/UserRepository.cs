using Microsoft.EntityFrameworkCore;
using OnlineShopCRM.Context;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<User?> GetUserById(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        return user;
    }

    public async Task<User?> GetUserByUsername(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

        return user;
    }

    public async Task UpdateUser(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
