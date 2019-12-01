using Domain.Infrastructure.Config.Objects;
using Domain.Updater.Configurations.Response.Const;

namespace Domain.Updater.Configurations.Response.Abstract
{
    public interface IConfigurationUpdateResponse
    {
        ConfigurationUpdateResponseEnum ResponseEnum { get; }
        ConfigurationObject Configuration { get; }
    }
}
