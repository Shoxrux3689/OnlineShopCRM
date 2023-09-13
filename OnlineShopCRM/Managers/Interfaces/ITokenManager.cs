using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Managers.Interfaces;

public interface ITokenManager
{
    string GenerateToken(User user);
}
