using System;
using Domain.Infrastructure.Config.Objects;
using Domain.Updater.Configurations.Response.Abstract;
using Domain.Updater.Configurations.Response.Const;

namespace Domain.Updater.Configurations.Response.Concrete
{
    public class ConfigurationUpdateResponse : IConfigurationUpdateResponse
    {
        public ConfigurationUpdateResponse(ConfigurationUpdateResponseEnum result)
        {
            if(result == ConfigurationUpdateResponseEnum.Success) throw new InvalidOperationException("Use constructor with object while success");
            ResponseEnum = result;
        }

        public ConfigurationUpdateResponse(ConfigurationObject configuration)
        {
            Configuration = configuration;
            ResponseEnum = Configuration == null ? ConfigurationUpdateResponseEnum.NotFound : ConfigurationUpdateResponseEnum.Success;
        }

        public ConfigurationUpdateResponseEnum ResponseEnum { get; }
        public ConfigurationObject Configuration { get; }
    }
}
