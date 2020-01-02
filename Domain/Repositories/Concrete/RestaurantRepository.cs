using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Data.DatabaseInfrastructure;
using Data.Infrastructure.StoredProceduresExecution.Abstract;
using Domain.BusinessObject;
using Domain.Repositories.Abstract;

namespace Domain.Repositories.Concrete
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly IStoredProceduresExecutor _storedProceduresExecutor;

        public RestaurantRepository(IStoredProceduresExecutor storedProceduresExecutor)
        {
            _storedProceduresExecutor = storedProceduresExecutor;
        }

        public async Task<Restaurant> CreateRestaurant(string name, string phoneNumber, bool isPyszne, decimal? minOrderCost, decimal? deliveryCost,
            decimal? maxPaidOrderValue)
        {
            IList<SqlParameter> parameters =new List<SqlParameter>
            {
                new SqlParameter("@Name",name),
                new SqlParameter("@PhoneNumber",phoneNumber),
                new SqlParameter("@IsPyszne",isPyszne),
                new SqlParameter("@MinOrderCost",minOrderCost),
                new SqlParameter("@DeliveryCost",deliveryCost),
                new SqlParameter("@MaxPaidOrderValue",maxPaidOrderValue)
            };

            DataSet ds = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.CreateRestaurant, parameters);
            return ReadFromDataSet(ds);
        }

        public async Task<Restaurant> EditRestaurant(Guid id, string name, string phoneNumber, bool isPyszne, decimal? minOrderCost,
            decimal? deliveryCost, decimal? maxPaidOrderValue)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Id",id),
                new SqlParameter("@Name",name),
                new SqlParameter("@PhoneNumber",phoneNumber),
                new SqlParameter("@IsPyszne",isPyszne),
                new SqlParameter("@MinOrderCost",minOrderCost ?? (object)DBNull.Value),
                new SqlParameter("@DeliveryCost",deliveryCost ?? (object)DBNull.Value),
                new SqlParameter("@MaxPaidOrderValue",maxPaidOrderValue ?? (object)DBNull.Value)
            };
            DataSet ds = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.EditRestaurant, parameters);
            return ReadFromDataSet(ds);
        }

        public async Task<Restaurant> GetRestaurant(Guid id)
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.GetRestaurant,
                new List<SqlParameter>
                {
                    new SqlParameter("@restaurantId", id)
                });
            return ReadFromDataSet(dataSet);
        }

        public async Task<IList<Restaurant>> GetRestaurants()
        {
            DataSet dataSet =
                await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.GetRestaurants,
                    new List<SqlParameter>());
            DataRowCollection rows =  dataSet.Tables[0].Rows;

            IList<Restaurant> result = new List<Restaurant>();
            foreach (DataRow row in rows)
            {
                result.Add(ReadFromDataRow(row));
            }

            return result;
        }

        public async Task RemoveRestaurant(Guid id)
        {
            await _storedProceduresExecutor.ExecuteNonQuery(StoredProceduresNames.RemoveRestaurant,
                new List<SqlParameter>
                {
                    new SqlParameter("@restaurantId",id)
                });
        }

        private static Restaurant ReadFromDataSet(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count == 0) return null;
            return ReadFromDataRow(ds.Tables[0].Rows[0]);
        }

        private static Restaurant ReadFromDataRow(DataRow row)
        {
            decimal? minOrderCost = row["RST_MinOrderCost"] == DBNull.Value ? null : (decimal?) row["RST_MinOrderCost"];
            decimal? deliveryCost = row["RST_DeliveryCost"] == DBNull.Value ? null : (decimal?) row["RST_DeliveryCost"];
            decimal? maxPaidOrderValue = row["RST_MaxPaidOrderValue"] == DBNull.Value ? null : (decimal?) row["RST_MaxPaidOrderValue"];

            return new Restaurant((Guid)(row["RST_Id"]), row["RST_Name"]?.ToString(), row["RST_PhoneNumber"]?.ToString(), (bool)row["RST_IsPyszne"], minOrderCost, deliveryCost, maxPaidOrderValue);

        }
    }
}
