using OnlineShopCRM.Entities;
using OnlineShopCRM.Models.UserModels;

namespace OnlineShopCRM.Managers.Interfaces;

public interface IUserManager
{
    Task<int> Registration(CreateUserModel createUserModel);
    Task<User> Login(LoginUserModel loginUserModel);
    Task UpdateUser(UpdateUserModel updateUserModel);
}
