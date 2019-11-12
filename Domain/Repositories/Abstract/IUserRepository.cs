using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;

namespace Domain.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task<User> GetUser(Guid id);
    }
}
