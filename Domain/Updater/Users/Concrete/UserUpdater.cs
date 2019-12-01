using System;
using System.Threading.Tasks;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Repositories.Abstract;
using Domain.Repositories.Responses;
using Domain.Updater.Users.Abstract;
using Domain.Updater.Users.Request.Abstract;
using Domain.Updater.Users.Response.Abstract;
using Domain.Updater.Users.Response.Concrete;
using Domain.Updater.Users.Response.Const;

namespace Domain.Updater.Users.Concrete
{
    public class UserUpdater : IUserUpdater
    {
        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;

        public UserUpdater(ILogger logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<IUserUpdateResponse> UpdateUser(IUserUpdateRequest request)
        {
            try
            {
                UserUpdateRepositoryResponse userUpdateRepositoryResponse = await _userRepository.EditUser(request.UserId, request.Email, request.Password,
                    string.IsNullOrWhiteSpace(request.Password));
                return userUpdateRepositoryResponse.Result switch
                {
                    UserUpdateResponseEnum.Success => new UserUpdateResponse(userUpdateRepositoryResponse.User),
                    UserUpdateResponseEnum.EmailAlreadyExists => new UserUpdateResponse(userUpdateRepositoryResponse.Result),
                    UserUpdateResponseEnum.UserNotFound => new UserUpdateResponse(userUpdateRepositoryResponse.Result),
                    UserUpdateResponseEnum.Exception => new UserUpdateResponse(userUpdateRepositoryResponse.Result),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new UserUpdateResponse(UserUpdateResponseEnum.Exception);
            }
        }
    }
}
