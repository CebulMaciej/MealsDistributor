using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Data.DatabaseInfrastructure;
using Data.Infrastructure.StoredProceduresExecution.Abstract;
using Domain.BusinessObject;
using Domain.Infrastructure.DataRowToObjectMapping.Abstract;
using Domain.Repositories.Abstract;

namespace Domain.Repositories.Concrete
{
    public class MealRepository : IMealRepository
    {
        private readonly IStoredProceduresExecutor _storedProceduresExecutor;
        private readonly IDataRowToObjectMapper _dataRowToObjectMapper;

        public MealRepository(IStoredProceduresExecutor storedProceduresExecutor, IDataRowToObjectMapper dataRowToObjectMapper)
        {
            _storedProceduresExecutor = storedProceduresExecutor;
            _dataRowToObjectMapper = dataRowToObjectMapper;
        }

        public async Task<Meal> GetMealById(Guid id)
        {
            DataSet dataSet = await
                _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.GetMealById, new List<SqlParameter> { new SqlParameter("@mealId",id) });

            return ExtractMealFromDataSet(dataSet);
        }

        public async Task<Meal> CreateMeal(string name, string description, decimal price, DateTime? startDate, DateTime? endDate,
            Guid restaurantId)
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.CreateMeal,
                new List<SqlParameter>
                {
                    new SqlParameter("@name",name),
                    new SqlParameter("@description",description),
                    new SqlParameter("@price",price),
                    new SqlParameter("@startDate",startDate),
                    new SqlParameter("@endDate",endDate),
                    new SqlParameter("@restaurantId",restaurantId)
                });

            return ExtractMealFromDataSet(dataSet);

        }

        public async Task<IList<Meal>> GetMealsByRestaurantId(Guid restaurantId)
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.GetMealsByRestaurantId,
                new List<SqlParameter> { new SqlParameter("@restaurantId",restaurantId)});
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            IList<Meal> meals = new List<Meal>(dataSet.Tables[1].Rows.Count);
            foreach (DataRow item in dataSet.Tables[1].Rows)
            {
               meals.Add(ExtractMealFromDataRow(item));
            }

            return meals;
        }

        public async Task<Meal> UpdateMeal(Guid id, string name, string description, decimal price, DateTime? startDate, DateTime? endDate,
            Guid restaurantId)
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.UpdateMeal,
                new List<SqlParameter>
                {
                    new SqlParameter("@mealId",id),
                    new SqlParameter("@name",name),
                    new SqlParameter("@description",description),
                    new SqlParameter("@price",price),
                    new SqlParameter("@startDate",startDate),
                    new SqlParameter("@endDate",endDate),
                    new SqlParameter("@restaurantId",restaurantId)
                });
            return ExtractMealFromDataSet(dataSet);
        }

        private Meal ExtractMealFromDataSet(DataSet dataSet)
        {
            DataRow dataRow = dataSet.Tables[0].Rows.Count == 0 ? null : dataSet.Tables[0].Rows[0];
            return ExtractMealFromDataRow(dataRow);
        }
        private Meal ExtractMealFromDataRow(DataRow dataRow)
        {
            return _dataRowToObjectMapper.ConvertMeal(dataRow);
        }
    }
}
