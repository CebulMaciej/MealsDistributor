using System;
using System.Data;
using System.Threading.Tasks;
using Data.Infrastructure.ProvidingSqlConnection.Abstract;
using Domain.Infrastructure.Logging.Abstract;
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
        private readonly ISqlConnectionProvider _sqlConnectionProvider;

        public UsersController(ILogger logger, ISqlConnectionProvider sqlConnectionProvider)
        {
            _logger = logger;
            _sqlConnectionProvider = sqlConnectionProvider;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetUserResponse))]
        public Task<ActionResult> GetUser()
        {
            try
            {
                var p = _sqlConnectionProvider.GetSqlConnection();
                //throw new InvalidConstraintException("Logging works");
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
