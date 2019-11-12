using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Providers.Users.Request.Abstract;
using Domain.Providers.Users.Response.Abstract;

namespace Domain.Providers.Users.Abstract
{
    public interface IUserProvider
    {
        Task<IProvideUserResponse> GetUserById(IProvideUserRequest provideUserRequest);
    }
}
