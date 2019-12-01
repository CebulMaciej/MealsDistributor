using System.Threading.Tasks;
using Domain.Updater.Configurations.Request.Abstract;
using Domain.Updater.Configurations.Response.Abstract;

namespace Domain.Updater.Configurations.Abstract
{
    public interface IConfigurationUpdater
    {
        Task<IConfigurationUpdateResponse> UpdateConfiguration(IConfigurationUpdateRequest configurationUpdateRequest);
    }
}
