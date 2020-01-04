using System;
using System.Collections.Generic;
using System.Text;
using Domain.Providers.Users.Request.Abstract;

namespace Domain.Providers.Users.Request.Concrete
{
    public class ProvideUserRequestToLogin : IProvideUserRequestToLogin
    {
        public ProvideUserRequestToLogin(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; }
        public string Password { get; }
    }
}
