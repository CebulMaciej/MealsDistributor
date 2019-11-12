using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Updater.Response.Abstract;
using Domain.Updater.Response.Const;

namespace Domain.Updater.Response.Concrete
{
    public class UserUpdateResponse : IUserUpdateResponse
    {
        public UserUpdateResponse(User user)
        {
            User = user;
        }

        public UserUpdateResponse(UserUpdateResponseEnum result)
        {
            Result = result;
            if(result == UserUpdateResponseEnum.Success) throw new InvalidOperationException("Cannot use this constructor while success");
        }

        public User User { get; }
        public UserUpdateResponseEnum Result { get; }
    }
}
