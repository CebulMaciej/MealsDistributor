using System;
using System.Data;
using System.Threading.Tasks;
using Data.Infrastructure.ProvidingSqlConnection.Abstract;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Users.Abstract;
using Domain.Providers.Users.Request.Concrete;
using Domain.Providers.Users.Response.Abstract;
using Domain.Repositories.Abstract;
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

        public UsersController(ILogger logger, IUserProvider userProvider)
        {
            _logger = logger;
            _userProvider = userProvider;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetUserResponse))]
        public async Task<ActionResult> GetUser()
        {
            try
            {
                IProvideUserResponse provideUserResponse = await _userProvider.GetUserById(
                    new ProvideUserRequest(new Guid("FBFE5353-6D96-44B6-BF5B-19D2135E693F")));
                return Ok(provideUserResponse);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }

            return null;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public Task<ActionResult> RegisterUser(AddUserRequest requestModel)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }

            return null;
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public Task<ActionResult> EditUser(EditConfigRequestModel requestModel)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }

            return null;
        }
    }
}
