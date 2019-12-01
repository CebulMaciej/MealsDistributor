using System;

namespace Domain.Updater.Users.Request.Abstract
{
    public interface IUserUpdateRequest
    {
        Guid UserId { get; }
        string Email { get; }
        string Password { get; }
    }
}
