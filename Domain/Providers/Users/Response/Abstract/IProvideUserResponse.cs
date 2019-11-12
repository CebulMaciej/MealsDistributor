using Domain.BusinessObject;

namespace Domain.Providers.Users.Response.Abstract
{
    public interface IProvideUserResponse
    {
        UserProvideResultEnum Result { get; }
        User User { get; }
    }
}
