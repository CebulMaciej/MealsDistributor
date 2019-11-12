using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Updater.Response.Const;

namespace Domain.Updater.Response.Abstract
{
    public interface IUserUpdateResponse
    {
        User User { get; }
        UserUpdateResponseEnum Result { get; }
    }
}
