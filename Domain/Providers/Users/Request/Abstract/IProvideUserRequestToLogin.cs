using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Providers.Users.Request.Abstract
{
    public interface IProvideUserRequestToLogin
    {
        string Login { get; }
        string Password { get; }
    }
}
