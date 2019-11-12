using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Updater.Request.Abstract
{
    public interface IUserUpdateRequest
    {
        Guid UserId { get; }
        string Email { get; }
        string Password { get; }
    }
}
