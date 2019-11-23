using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure.Config.Objects;

namespace Domain.Repositories.Abstract
{
    public interface IConfigurationRepository
    {
        Task<ConfigurationObject> GetConfigurationObject(string key);
        Task<ConfigurationObject> UpdateConfigurationObject(string key,string value);
    }
}
