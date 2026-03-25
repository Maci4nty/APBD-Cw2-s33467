using System;
using APBD02.Enums;

namespace APBD02.Models;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserType Type { get; set; }

    public User(Guid id, string firstName, string lastName, UserType type)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Type = type;
    }
}