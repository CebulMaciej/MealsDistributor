using System;
using System.Collections.Generic;
using System.Text;
using Domain.Infrastructure.Config.Objects;
using Domain.Updater.Response.Const;

namespace Domain.Updater.Response.Abstract
{
    public interface IConfigurationUpdateResponse
    {
        ConfigurationUpdateResponseEnum ResponseEnum { get; }
        ConfigurationObject Configuration { get; }
    }
}
