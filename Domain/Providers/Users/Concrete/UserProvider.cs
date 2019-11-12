using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Users.Abstract;
using Domain.Providers.Users.Request.Abstract;
using Domain.Providers.Users.Response;
using Domain.Providers.Users.Response.Abstract;
using Domain.Providers.Users.Response.Concrete;
using Domain.Repositories.Abstract;

namespace Domain.Providers.Users.Concrete
{
    public class UserProvider : IUserProvider
    {
        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;

        public UserProvider(ILogger logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<IProvideUserResponse> GetUserById(IProvideUserRequest provideUserRequest)
        {
            try
            {
                User user = await _userRepository.GetUser(provideUserRequest.Id);
                // ReSharper disable once ConvertIfStatementToReturnStatement
                if (user == null)
                {
                    return new ProvideUserResponse(UserProvideResultEnum.NotFound);
                }
                return new ProvideUserResponse(user);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new ProvideUserResponse(UserProvideResultEnum.Exception);
            }
        }
    }
}
