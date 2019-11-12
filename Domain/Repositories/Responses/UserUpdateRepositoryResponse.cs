using Domain.BusinessObject;
using Domain.Updater.Response.Const;

namespace Domain.Repositories.Responses
{
    public class UserUpdateRepositoryResponse
    {
        public UserUpdateRepositoryResponse(UserUpdateResponseEnum result, User user)
        {
            Result = result;
            User = user;
        }

        public UserUpdateResponseEnum Result { get; }
        public User User { get; }
    }
}
