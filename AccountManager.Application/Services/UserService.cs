using System;
using AccountManager.Application.DTOs.User;
using AccountManager.Application.Exceptions;
using AccountManager.Application.Interfaces;
using AccountManager.Domain.Entities;
using AccountManager.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Application.Services;

public class UserService(
    AccountManagerDbContext context,
    ICryptService cryptService,
    IJwtService jwtService) : IUserService
{
    private static string GenerateAccountNumber()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
    }

    public async Task CreateUser(CreateUserDTO createUserDTO)
    {
        var userExists = await context.Users
            .AsNoTracking()
            .AnyAsync(u => u.Email == createUserDTO.Email);

        if (userExists)
        {
            throw new BadRequestException("Este email ja esta cadastrado");
        }

        var newAccountNumber = GenerateAccountNumber();

        var user = new User
        {
            Name = createUserDTO.Name,
            Email = createUserDTO.Email,
            Password = cryptService.HashString(createUserDTO.Password),
            AccountNumber = newAccountNumber,
        };

        var account = new Account
        {
            Number = newAccountNumber,
            UserId = user.Id,
        };

        user.Account = account;

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task<GetUserLoginDTO> UserLogin(string email, string senha)
    {
        var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);

        if (user == null)
        {
            throw new NotFoundException("Usuario nao encontrado");
        }

        if (!cryptService.CompareString(senha, user.Password))
        {
            throw new BadRequestException("Senha invalida");
        }

        var (token, expiresAt) = jwtService.GenerateToken(user);

        return new GetUserLoginDTO(
            token,
            expiresAt,
            user.Id.ToString(), user.AccountNumber);
    }
}
