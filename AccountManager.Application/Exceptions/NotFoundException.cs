using System;

namespace AccountManager.Application.Exceptions;

public class NotFoundException(string message) : Exception(message)
{

}
