using System;
using Domain.Updater.Request.Abstract;

namespace Domain.Updater.Request.Concrete
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
