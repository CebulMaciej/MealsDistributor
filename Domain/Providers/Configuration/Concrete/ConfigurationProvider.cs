using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure.Config.Objects;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Configuration.Abstract;
using Domain.Providers.Configuration.Request.Abstract;
using Domain.Providers.Configuration.Response.Abstract;
using Domain.Providers.Configuration.Response.Concrete;
using Domain.Providers.Configuration.Response.Const;
using Domain.Repositories.Abstract;

namespace Domain.Providers.Configuration.Concrete
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        private readonly ILogger _logger;
        private readonly IConfigurationRepository _configurationRepository;

        public ConfigurationProvider(ILogger logger, IConfigurationRepository configurationRepository)
        {
            _logger = logger;
            _configurationRepository = configurationRepository;
        }

        public async Task<IGetConfigurationResponse> GetConfigurationResponse(IGetConfigurationRequest getConfigurationRequest)
        {
            try
            {
                if (!getConfigurationRequest.IsValid)
                {
                    return new GetConfigurationResponse(GetConfigurationResultEnum.InvalidKey);
                }

                ConfigurationObject configurationObject = await _configurationRepository.GetConfigurationObject(getConfigurationRequest.Key);
                return new GetConfigurationResponse(configurationObject);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new GetConfigurationResponse(GetConfigurationResultEnum.Exception);
            }
        }
    }
}
