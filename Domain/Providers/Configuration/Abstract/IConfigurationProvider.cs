using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Providers.Configuration.Request.Abstract;
using Domain.Providers.Configuration.Response.Abstract;

namespace Domain.Providers.Configuration.Abstract
{
    public interface IConfigurationProvider
    {
        Task<IGetConfigurationResponse> GetConfigurationResponse(IGetConfigurationRequest getConfigurationRequest);
    }
}
