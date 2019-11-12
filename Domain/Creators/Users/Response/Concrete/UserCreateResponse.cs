using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Creators.Users.Response.Abstract;
using Domain.Creators.Users.Response.Const;

namespace Domain.Creators.Users.Response.Concrete
{
    public class UserCreateResponse : IUserCreateResponse
    {
        public UserCreateResponse( User user)
        {
            Result = CreateUserResponseEnum.Success;
            User = user;
        }

        public UserCreateResponse(CreateUserResponseEnum result)
        {
            Result = result;
            if (result == CreateUserResponseEnum.Success)
            {
                throw new InvalidOperationException("Cannot return only enum while success");
            }
        }

        public CreateUserResponseEnum Result { get; }
        public User User { get; }
    }
}
