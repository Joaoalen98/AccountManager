using System;

namespace AccountManager.Application.Interfaces;

public interface ICryptService
{
    string HashString(string password);
    bool CompareString(string password, string hash);
}
