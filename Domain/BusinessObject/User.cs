using System;
using System.Collections.Generic;
using System.Text;
using Domain.Object.Claims;

namespace Domain.BusinessObject
{
    public class User
    {
        public User(Guid id, string email, string password, DateTime creationDate, UserRole role)
        {
            Id = id;
            Email = email;
            Password = password;
            CreationDate = creationDate;
            Role = role;
        }

        public Guid Id { get; }
        public string Email { get; }
        public string Password { get; }
        public DateTime CreationDate { get; }
        public UserRole Role { get; }
    }
}
