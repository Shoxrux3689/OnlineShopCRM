using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Managers.Interfaces;

public interface ITokenManager
{
    string GetToken(User user);
}
