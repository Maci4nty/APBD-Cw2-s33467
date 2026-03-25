using System;

namespace APBD02.Exceptions;

public class UserLimitExceededException : Exception
{
    public UserLimitExceededException(string? msg) : base(msg) { }
}