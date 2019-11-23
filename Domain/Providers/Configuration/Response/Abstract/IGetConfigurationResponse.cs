using System;
using System.Collections.Generic;
using System.Text;
using Domain.Infrastructure.Config.Objects;
using Domain.Providers.Configuration.Response.Const;

namespace Domain.Providers.Configuration.Response.Abstract
{
    public interface IGetConfigurationResponse
    {
        GetConfigurationResultEnum Result { get; }
        ConfigurationObject ConfigurationObject { get; }
    }
}
