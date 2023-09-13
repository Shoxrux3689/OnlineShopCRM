using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Repositories.Interfaces;

public interface IUserRepository
{
    Task<int> AddUser(User user);
    Task UpdateUser(User user);
    Task<User?> GetUser(int id);
}
