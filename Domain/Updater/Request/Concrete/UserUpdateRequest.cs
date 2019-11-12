using Domain.Updater.Request.Abstract;

namespace Domain.Updater.Request.Concrete
{
    public class UserUpdateRequest : IUserUpdateRequest
    {
        public UserUpdateRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; }
        public string Password { get; }
    }
}
