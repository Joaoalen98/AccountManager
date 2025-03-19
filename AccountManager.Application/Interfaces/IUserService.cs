using System;
using AccountManager.Application.DTOs.User;

namespace AccountManager.Application.Interfaces;

public interface IUserService
{
    Task CreateUser(CreateUserDTO createUserDTO);
    Task<GetUserLoginDTO> UserLogin(string email, string senha);
}
