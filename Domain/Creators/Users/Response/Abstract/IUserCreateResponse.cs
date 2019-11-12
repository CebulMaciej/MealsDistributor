using Domain.BusinessObject;
using Domain.Creators.Users.Response.Const;

namespace Domain.Creators.Users.Response.Abstract
{
    public interface IUserCreateResponse
    {
        CreateUserResponseEnum Result { get; }
        User User { get; }
    }
}
