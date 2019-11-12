using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Creators.Users.Abstract;
using Domain.Creators.Users.Request.Abstract;
using Domain.Creators.Users.Response.Abstract;
using Domain.Creators.Users.Response.Concrete;
using Domain.Creators.Users.Response.Const;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Repositories.Abstract;

namespace Domain.Creators.Users.Concrete
{
    public class UserCreator : IUserCreator
    {
        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;

        public UserCreator(IUserRepository userRepository, ILogger logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<IUserCreateResponse> CreateUser(IUserCreateRequest userCreateRequest)
        {
            try
            {
                User user = await _userRepository.AddUser(userCreateRequest.Email, userCreateRequest.Password);
                if (user == null)
                {
                    return new UserCreateResponse(CreateUserResponseEnum.EmailAlreadyExists);
                }
                return new UserCreateResponse(user);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new UserCreateResponse(CreateUserResponseEnum.Exception);
            }
        }
    }
}
