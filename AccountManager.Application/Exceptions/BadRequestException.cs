using System;

namespace AccountManager.Application.Exceptions;

public class BadRequestException(string message) : Exception(message)
{

}
