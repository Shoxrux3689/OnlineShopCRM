﻿using Microsoft.AspNetCore.Identity;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models.UserModels;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Managers;

public class UserManager : IUserManager
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenManager _tokenManager;
    public UserManager(IUserRepository userRepository, ITokenManager tokenManager)
    {
        _userRepository = userRepository;
        _tokenManager = tokenManager;
    }

    public async Task<int> Registration(CreateUserModel createUserModel)
    {
        //username 2ta bolib qolmasligini oldini olib ketishim kerak
        var user = new User()
        {
            Username = createUserModel.Username,
            PhoneNumber = createUserModel.PhoneNumber,
        };

        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, createUserModel.Password);

        await _userRepository.AddUser(user);

        return user.Id;
    }

    public async Task<string> Login(LoginUserModel loginUserModel)
    {
        var user = await _userRepository.GetUserByUsername(loginUserModel.Username);
        if (user == null)
            throw new Exception("Username is not found");
        
        var result = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, loginUserModel.Password);
        if (result != PasswordVerificationResult.Success)
        {
            throw new Exception("Password is incorrect");
        }

        var token = _tokenManager.GenerateToken(user);

        return token;
    }

    public Task UpdateUser(UpdateUserModel updateUserModel)
    {
        //hozircha implementatsiya qilmadim
        throw new NotImplementedException();
    }
}
