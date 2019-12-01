using System;
using Domain.Updater.Users.Request.Abstract;

namespace Domain.Updater.Users.Request.Concrete
{
    public class UserUpdateRequest : IUserUpdateRequest
    {
        public UserUpdateRequest(string email, string password, Guid userId)
        {
            Email = email;
            Password = password;
            UserId = userId;
        }

        public Guid UserId { get; }
        public string Email { get; }
        public string Password { get; }
    }
}
