using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Providers.Users.Response
{
    public enum UserProvideResultEnum
    {
        Success,
        NotFound,
        Exception,
        Forbidden
    }
}
