using System;
using System.Collections.Generic;
using System.Text;
using Domain.Infrastructure.Config.Objects;
using Domain.Providers.Configuration.Response.Abstract;
using Domain.Providers.Configuration.Response.Const;

namespace Domain.Providers.Configuration.Response.Concrete
{
    public class GetConfigurationResponse : IGetConfigurationResponse
    {
        public GetConfigurationResponse(ConfigurationObject configurationObject)
        {
            if (configurationObject == null)
            {
                Result = GetConfigurationResultEnum.NotFound;
            }
            else
            {
                Result = GetConfigurationResultEnum.Success;
                ConfigurationObject = configurationObject;
            }
        }

        public GetConfigurationResponse(GetConfigurationResultEnum result)
        {
            Result = result;
            if (result == GetConfigurationResultEnum.Success) throw new InvalidOperationException("while success use constructor with config object");
        }

        public GetConfigurationResultEnum Result { get; }
        public ConfigurationObject ConfigurationObject { get; }
    }
}
