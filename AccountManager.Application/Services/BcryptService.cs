using System;
using AccountManager.Application.Interfaces;
using static BCrypt.Net.BCrypt;

namespace AccountManager.Application.Services;

public class BcryptService : ICryptService
{
    public string HashString(string password)
    {
        return HashPassword(password, GenerateSalt(8));
    }

    public bool CompareString(string password, string hash)
    {
        return Verify(password, hash);
    }
}
