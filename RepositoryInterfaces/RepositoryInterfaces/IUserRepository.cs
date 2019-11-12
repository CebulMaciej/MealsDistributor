using System;
using System.Threading.Tasks;

namespace RepositoryInterfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(Guid id);
    }
}
