using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Domain.BusinessObject;
using Domain.Infrastructure.Config.Objects;
using Domain.Infrastructure.DataRowToObjectMapping.Abstract;
using Domain.Object.Claims;

namespace Domain.Infrastructure.DataRowToObjectMapping.Concrete
{
    public class DataRowToObjectMapper : IDataRowToObjectMapper
    {
        
        public Meal ConvertMeal(DataRow dataRow)
        {
            if (dataRow == null)
            {
                return null;
            }

            Guid id = (Guid) dataRow["MLS_Id"];
            string name = dataRow["MLS_Name"].ToString();
            string description = dataRow["MLS_Description"].ToString();
            decimal price = (decimal) dataRow["MLS_Price"];
            DateTime? startDate = dataRow["MLS_StartDate"] == DBNull.Value
                ? (DateTime?) null
                : (DateTime) dataRow["MLS_StartDate"];
            DateTime? endDate = dataRow["MLS_EndDate"] == DBNull.Value
                ? (DateTime?)null
                : (DateTime)dataRow["MLS_EndDate"];
            Guid restaurantId = (Guid) dataRow["MLS_RestaurantId"];


            return new Meal(id, name, description, price, startDate, endDate, restaurantId);
        }

        public Restaurant ConvertRestaurant(DataRow dataRow)
        {
            if (dataRow == null)
            {
                return null;
            }

            Guid id = (Guid) dataRow["RST_Id"];
            string name = dataRow["RST_Name"].ToString();
            string phoneNumber = dataRow["RST_PhoneNumber"].ToString();
            // ReSharper disable once IdentifierTypo
            bool isPyszne = (bool) dataRow["RST_IsPyszne"];
            decimal? minOrderCost = dataRow["RST_MinOrderCost"] == DBNull.Value
                ? (decimal?) null
                : (decimal) dataRow["RST_MinOrderCost"];

            decimal? deliveryCost = dataRow["RST_DeliveryCost"] == DBNull.Value
                ? (decimal?)null
                : (decimal)dataRow["RST_DeliveryCost"];

            decimal? maxPaidDeliveryOrderValue = dataRow["RST_MaxPaidOrderValue"] == DBNull.Value
                ? (decimal?)null
                : (decimal)dataRow["RST_MaxPaidOrderValue"];

            return new Restaurant(id, name, phoneNumber, isPyszne, minOrderCost, deliveryCost, maxPaidDeliveryOrderValue);
        }

        public ConfigurationObject ConvertConfigurationObject(DataRow dataRow)
        {
            if (dataRow == null)
            {
                return null;
            }
            return new ConfigurationObject(dataRow["CON_Key"].ToString(), dataRow["CON_Value"].ToString());
        }

        public User ConvertUser(DataRow dataRow)
        {
            if (dataRow == null)
            {
                return null;
            }
            return new User(
                Guid.Parse(dataRow["USR_Id"].ToString()),
                dataRow["USR_Email"].ToString(),
                dataRow["USR_Password"].ToString(),
                DateTime.Parse(dataRow["USR_CreationDate"].ToString()),
                (UserRole)int.Parse(dataRow["USR_Role"].ToString())
            );
        }

        public Order ConvertOrder(DataRow dataRow)
        {
            if (dataRow == null) return null;
            return new Order(Guid.Parse(dataRow["ORD_Id"].ToString()),DateTime.Parse(dataRow["ORD_CreationDate"].ToString()),Guid.Parse(dataRow["ORD_OrderBoyId"].ToString()),bool.Parse(dataRow["ORD_IsOrdered"].ToString()),Guid.Parse(dataRow["ORD_RestaurantId"].ToString()));
        }

        public OrderPosition ConvertOrderPosition(DataRow dataRow)
        {
            if (dataRow == null) return null;
            return new OrderPosition(Guid.Parse(dataRow["OP_Id"].ToString()),DateTime.Parse(dataRow["OP_CreationDate"].ToString()),Guid.Parse(dataRow["OP_UserId"].ToString()),GetGuidFromRow(dataRow,"OP_MealId"),GetGuidFromRow(dataRow,"OP_OrderId"));
        }

        public OrderProposition ConvertOrderProposition(DataRow dataRow)
        {
            if (dataRow == null) return null;
            return new OrderProposition(GetGuidFromRow(dataRow,"OrdProp_Id"),GetDateTimeFromRow(dataRow,"OrdProp_CreationDate"),GetDateTimeFromRow(dataRow,"OrdProp_TimeToOrdering"),GetGuidFromRow(dataRow,"OrdProp_CreatorId"),GetGuidFromRow(dataRow,"OrdProp_RestaurantId"),(bool)dataRow["OrdProp_OrderingStopped"]);
        }

        public OrderPropositionPosition ConvertOrderPropositionPosition(DataRow dataRow)
        {
            if (dataRow == null) return null;
            return new OrderPropositionPosition(GetGuidFromRow(dataRow, "OPP_Id"),GetDateTimeFromRow(dataRow, "OPP_CreationDate"),GetGuidFromRow(dataRow, "OPP_UserId"),GetGuidFromRow(dataRow, "OPP_MealId"),GetGuidFromRow(dataRow, "Opp_OrderPropositionId"));
        }

        private static Guid GetGuidFromRow(DataRow row, string key) => Guid.Parse(row[key].ToString());
        private static DateTime GetDateTimeFromRow(DataRow row, string key) => DateTime.Parse(row[key].ToString());
        
    }
}
