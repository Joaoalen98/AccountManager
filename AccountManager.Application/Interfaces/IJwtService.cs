using System;
using AccountManager.Domain.Entities;

namespace AccountManager.Application.Interfaces;

public interface IJwtService
{
    (string token, DateTime expiresAt) GenerateToken(User user);
}