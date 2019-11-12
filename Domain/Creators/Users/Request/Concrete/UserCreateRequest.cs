using System;
using System.Collections.Generic;
using System.Text;
using Domain.Creators.Users.Request.Abstract;

namespace Domain.Creators.Users.Request.Concrete
{
    public class UserCreateRequest : IUserCreateRequest
    {
        public UserCreateRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; }
        public string Password { get; }
    }
}
