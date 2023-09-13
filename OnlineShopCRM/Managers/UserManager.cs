using OnlineShopCRM.Entities;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models.UserModels;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Managers;

public class UserManager : IUserManager
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<int> Registration(CreateUserModel createUserModel)
    {
        throw new NotImplementedException();
    }

    public Task<User> Login(LoginUserModel loginUserModel)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateUser(UpdateUserModel updateUserModel)
    {
        //hozircha implementatsiya qilmadim
        throw new NotImplementedException();
    }
}
