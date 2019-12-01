using System.Threading.Tasks;
using Domain.Updater.Users.Request.Abstract;
using Domain.Updater.Users.Response.Abstract;

namespace Domain.Updater.Users.Abstract
{
    public interface IUserUpdater
    {
        Task<IUserUpdateResponse> UpdateUser(IUserUpdateRequest request);
    }
}
