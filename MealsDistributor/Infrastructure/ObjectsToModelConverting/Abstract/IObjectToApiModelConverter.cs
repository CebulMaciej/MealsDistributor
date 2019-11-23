using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Infrastructure.Config.Objects;
using MealsDistributor.Model.ApiModels;

namespace MealsDistributor.Infrastructure.ObjectsToModelConverting.Abstract
{
    public interface IObjectToApiModelConverter
    {
        UserApiModel ConvertUser(User user);
        ConfigurationApiModel ConvertConfiguration(ConfigurationObject configurationObject);
    }
}
