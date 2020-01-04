using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Domain.BusinessObject;
using Domain.Infrastructure.Config.Objects;

namespace Domain.Infrastructure.DataRowToObjectMapping.Abstract
{
    public interface IDataRowToObjectMapper
    {
        Meal ConvertMeal(DataRow dataRow);
        Restaurant ConvertRestaurant(DataRow dataRow);
        ConfigurationObject ConvertConfigurationObject(DataRow datarow);
        User ConvertUser(DataRow dataRow);

        Order ConvertOrder(DataRow dataRow);

        OrderPosition ConvertOrderPosition(DataRow dataRow);
    }
}
