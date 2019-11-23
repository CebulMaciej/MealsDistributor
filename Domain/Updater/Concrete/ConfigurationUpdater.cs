using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure.Config.Objects;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Repositories.Abstract;
using Domain.Updater.Abstract;
using Domain.Updater.Request.Abstract;
using Domain.Updater.Response.Abstract;
using Domain.Updater.Response.Concrete;
using Domain.Updater.Response.Const;

namespace Domain.Updater.Concrete
{
    public class ConfigurationUpdater : IConfigurationUpdater
    {
        private readonly ILogger _logger;
        private readonly IConfigurationRepository _configurationRepository;

        public ConfigurationUpdater(IConfigurationRepository configurationRepository, ILogger logger)
        {
            _configurationRepository = configurationRepository;
            _logger = logger;
        }

        public async Task<IConfigurationUpdateResponse> UpdateConfiguration(IConfigurationUpdateRequest configurationUpdateRequest)
        {
            try
            {
                if(!configurationUpdateRequest.IsValid) return new ConfigurationUpdateResponse(ConfigurationUpdateResponseEnum.BadRequest);

                ConfigurationObject updateConfigurationObject = await _configurationRepository.UpdateConfigurationObject(configurationUpdateRequest.Key,
                    configurationUpdateRequest.Value);

                return new ConfigurationUpdateResponse(updateConfigurationObject);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new ConfigurationUpdateResponse(ConfigurationUpdateResponseEnum.Exception);
            }
        }
    }
}
