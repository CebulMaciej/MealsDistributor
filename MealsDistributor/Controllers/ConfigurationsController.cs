using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Configuration.Abstract;
using Domain.Providers.Configuration.Request.Abstract;
using Domain.Providers.Configuration.Request.Concrete;
using Domain.Providers.Configuration.Response.Abstract;
using Domain.Providers.Configuration.Response.Const;
using Domain.Updater.Configurations.Abstract;
using Domain.Updater.Configurations.Request.Abstract;
using Domain.Updater.Configurations.Request.Concrete;
using Domain.Updater.Configurations.Response.Abstract;
using Domain.Updater.Configurations.Response.Const;
using MealsDistributor.Infrastructure.ObjectsToModelConverting.Abstract;
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
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IConfigurationUpdater _configurationUpdater;
        private readonly IObjectToApiModelConverter _objectToApiModelConverter;

        public ConfigurationsController(ILogger logger, IConfigurationProvider configurationProvider, IConfigurationUpdater configurationUpdater, IObjectToApiModelConverter objectToApiModelConverter)
        {
            _logger = logger;
            _configurationProvider = configurationProvider;
            _configurationUpdater = configurationUpdater;
            _objectToApiModelConverter = objectToApiModelConverter;
        }


        [HttpGet("{key}")]
        [ProducesResponseType(200,Type = typeof(GetConfigurationResponseModel))]
        public async Task<ActionResult> GetConfig(string key)
        {
            try
            {
                IGetConfigurationRequest getConfigurationRequest = new GetConfigurationRequest(key);
                IGetConfigurationResponse getConfigurationResponse = await _configurationProvider.GetConfigurationResponse(getConfigurationRequest);
                return PrepareResponseAfterGetConfiguration(getConfigurationResponse);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }

        }

        private ActionResult PrepareResponseAfterGetConfiguration(IGetConfigurationResponse getConfigurationResponse)
        {
            // ReSharper disable once ConvertSwitchStatementToSwitchExpression
            switch (getConfigurationResponse.Result)
            {
                case GetConfigurationResultEnum.Exception:
                    return StatusCode(500);
                case GetConfigurationResultEnum.Success:
                    return StatusCode(200, new ConfigurationApiModel
                    {
                        Key = getConfigurationResponse.ConfigurationObject.Key,
                        Value = getConfigurationResponse.ConfigurationObject.Value
                    });
                case GetConfigurationResultEnum.NotFound:
                    return StatusCode(404);
                case GetConfigurationResultEnum.InvalidKey:
                    return StatusCode(400);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<ActionResult> UpdateConfiguration(EditConfigRequestModel updateRequest)
        {
            try
            {
                IConfigurationUpdateRequest updateConfigurationRequest = new ConfigurationUpdateRequest(updateRequest.Key,updateRequest.Value);
                IConfigurationUpdateResponse configurationUpdateResponse = await _configurationUpdater.UpdateConfiguration(updateConfigurationRequest);
                return PrepareResponseAfterUpdateConfigurationResponse(configurationUpdateResponse);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }

        private ActionResult PrepareResponseAfterUpdateConfigurationResponse(IConfigurationUpdateResponse configurationUpdateResponse)
        {
            switch (configurationUpdateResponse.ResponseEnum)
            {
                case ConfigurationUpdateResponseEnum.Exception:
                    return StatusCode(500);
                case ConfigurationUpdateResponseEnum.Success:
                    return StatusCode(200, _objectToApiModelConverter.ConvertConfiguration(configurationUpdateResponse.Configuration));
                case ConfigurationUpdateResponseEnum.NotFound:
                    return StatusCode(404);
                case ConfigurationUpdateResponseEnum.BadRequest:
                    return StatusCode(400);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
