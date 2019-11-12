using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Infrastructure.Logging.Abstract;
using MealsDistributor.Model;
using MealsDistributor.Model.ApiModels;
using MealsDistributor.Model.Request;
using MealsDistributor.Model.Request.Config;
using MealsDistributor.Model.Response;
using MealsDistributor.Model.Response.Config;
using Microsoft.AspNetCore.Mvc;

namespace MealsDistributor.Controllers
{
    [Route("api/configurations")]
    [ApiController]
    
    public class ConfigurationsController : ControllerBase
    {

        private readonly ILogger _logger;

        public ConfigurationsController(ILogger logger)
        {
            _logger = logger;
        }


        [HttpGet("{key}")]
        [ProducesResponseType(200,Type = typeof(GetConfigurationResponseModel))]
        public Task<ActionResult> GetConfig(string key)
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
        public Task<ActionResult> GetConfig(EditConfigRequestModel editRequest)
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
