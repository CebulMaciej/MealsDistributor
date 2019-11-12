using System;
using System.Data;
using System.Threading.Tasks;
using Data.Infrastructure.ProvidingSqlConnection.Abstract;
using Domain.Creators.Users.Abstract;
using Domain.Creators.Users.Request.Abstract;
using Domain.Creators.Users.Request.Concrete;
using Domain.Creators.Users.Response.Abstract;
using Domain.Creators.Users.Response.Const;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Users.Abstract;
using Domain.Providers.Users.Request.Concrete;
using Domain.Providers.Users.Response;
using Domain.Providers.Users.Response.Abstract;
using Domain.Repositories.Abstract;
using Domain.Updater.Abstract;
using Domain.Updater.Request.Abstract;
using Domain.Updater.Request.Concrete;
using Domain.Updater.Response.Abstract;
using Domain.Updater.Response.Const;
using MealsDistributor.Infrastructure.ObjectsToModelConverting.Abstract;
using MealsDistributor.Model.Request.Config;
using MealsDistributor.Model.Request.User;
using MealsDistributor.Model.Response.User;
using Microsoft.AspNetCore.Mvc;

namespace MealsDistributor.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserProvider _userProvider;
        private readonly IUserCreator _userCreator;
        private readonly IObjectToApiModelConverter _objectToApiModelConverter;
        private readonly IUserUpdater _userUpdater;

        public UsersController(ILogger logger, IUserProvider userProvider, IUserCreator userCreator, IObjectToApiModelConverter objectToApiModelConverter, IUserUpdater userUpdater)
        {
            _logger = logger;
            _userProvider = userProvider;
            _userCreator = userCreator;
            _objectToApiModelConverter = objectToApiModelConverter;
            _userUpdater = userUpdater;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetUserResponse))]
        public async Task<ActionResult> GetUser()
        {
            try
            {
                IProvideUserResponse provideUserResponse = await _userProvider.GetUserById(
                    new ProvideUserRequest(new Guid("FBFE5353-6D96-44B6-BF5B-19D2135E693F")));
                return PrepareResponseAfterGetUser(provideUserResponse);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }

        }

        private ActionResult PrepareResponseAfterGetUser(IProvideUserResponse provideUserResponse)
        {
            return provideUserResponse.Result switch
            {
                UserProvideResultEnum.Success => (ActionResult) Ok(
                    _objectToApiModelConverter.ConvertUser(provideUserResponse.User)),
                UserProvideResultEnum.NotFound => StatusCode(404),
                UserProvideResultEnum.Exception => StatusCode(500),
                UserProvideResultEnum.Forbidden => StatusCode(403),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult> RegisterUser(AddUserRequest requestModel)
        {
            try
            {
                if (!requestModel.IsValid) return StatusCode(400);
                IUserCreateRequest userCreateRequest = new UserCreateRequest(requestModel.Email,requestModel.Password);
                IUserCreateResponse userCreateResponse = await _userCreator.CreateUser(userCreateRequest);
                return PrepareResponseAfterRegisterUser(userCreateResponse);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }

        private ActionResult PrepareResponseAfterRegisterUser(IUserCreateResponse userCreateResponse)
        {
            return userCreateResponse.Result switch
            {
                CreateUserResponseEnum.Success => StatusCode(200),
                CreateUserResponseEnum.Exception => StatusCode(500),
                CreateUserResponseEnum.EmailAlreadyExists => StatusCode(409),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<ActionResult> EditUser(EditUserRequest requestModel)
        {
            try
            {
                if (!requestModel.IsValid)
                {
                    return StatusCode(400);
                }

                IUserUpdateRequest userUpdateRequest = new UserUpdateRequest(requestModel.Email,requestModel.Password);
                IUserUpdateResponse userUpdateResponse = await _userUpdater.UpdateUser(userUpdateRequest);
                return PrepareResponseAfterEditUser(userUpdateResponse);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }

            return null;
        }

        private ActionResult PrepareResponseAfterEditUser(IUserUpdateResponse userUpdateResponse)
        {
            return userUpdateResponse.Result switch
            {
                UserUpdateResponseEnum.Success => (Ok(userUpdateResponse.User) as ActionResult),
                UserUpdateResponseEnum.EmailAlreadyExists => StatusCode(409),
                UserUpdateResponseEnum.UserNotFound => StatusCode(404),
                UserUpdateResponseEnum.Exception => StatusCode(500),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
