using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Creators.Users.Request.Abstract;
using Domain.Creators.Users.Response.Abstract;
using Domain.Creators.Users.Response.Concrete;

namespace Domain.Creators.Users.Abstract
{
    public interface IUserCreator
    {
        Task<IUserCreateResponse> CreateUser(IUserCreateRequest userCreateRequest);
    }
}
