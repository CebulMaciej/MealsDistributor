using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Repositories.Responses;

namespace Domain.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task<User> GetUser(Guid id);
        Task<User> AddUser(string email,string password);
        Task<UserUpdateRepositoryResponse> EditUser(Guid id,string email, string password,bool changePassword = false);
        Task<User> GetUserByLoginAndPassword(string login, string password);
    }
}
