using Domain.Updater.Users.Response.Const;

namespace Domain.Updater.Users.Response.Abstract
{
    public interface IUserUpdateResponse
    {
        BusinessObject.User User { get; }
        UserUpdateResponseEnum Result { get; }
    }
}
