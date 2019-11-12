using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.Users.Response.Abstract;

namespace Domain.Providers.Users.Response.Concrete
{
    public class ProvideUserResponse : IProvideUserResponse
    {
        public ProvideUserResponse(User user)
        {
            User = user;
        }
        public ProvideUserResponse(UserProvideResultEnum result)
        {
            Result = result;
            if(result == UserProvideResultEnum.Success) throw new InvalidOperationException("Cannot use success result without object");
        }
        public UserProvideResultEnum Result { get; }
        public User User { get; }
    }
}
