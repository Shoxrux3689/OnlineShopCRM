using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Repositories.Interfaces;

public interface IUserRepository
{
    Task<int> AddUser(User user);
    Task UpdateUser(User user);
    Task<User?> GetUserById(int id);
    Task<User?> GetUserByUsername(string username);
}
