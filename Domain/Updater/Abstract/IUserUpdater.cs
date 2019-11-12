using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Updater.Request.Abstract;
using Domain.Updater.Response.Abstract;

namespace Domain.Updater.Abstract
{
    public interface IUserUpdater
    {
        Task<IUserUpdateResponse> UpdateUser(IUserUpdateRequest request);
    }
}
