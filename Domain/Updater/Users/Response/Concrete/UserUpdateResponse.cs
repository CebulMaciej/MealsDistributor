using System;
using Domain.Updater.Users.Response.Abstract;
using Domain.Updater.Users.Response.Const;

namespace Domain.Updater.Users.Response.Concrete
{
    public class UserUpdateResponse : IUserUpdateResponse
    {
        public UserUpdateResponse(BusinessObject.User user)
        {
            User = user;
        }

        public UserUpdateResponse(UserUpdateResponseEnum result)
        {
            Result = result;
            if(result == UserUpdateResponseEnum.Success) throw new InvalidOperationException("Cannot use this constructor while success");
        }

        public BusinessObject.User User { get; }
        public UserUpdateResponseEnum Result { get; }
    }
}
