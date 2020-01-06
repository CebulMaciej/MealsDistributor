using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DatabaseInfrastructure
{
    public static class StoredProceduresNames
    {
        public static string GetUserById = "GetUserById";
        public static string AddUser = "AddUser";
        public static string EditUser = "EditUser";
        public static string GetUserByLoginAndPassword = "GetUserByLoginAndPassword";

        public static string GetConfiguration = "GetConfiguration";
        public static string UpdateConfigurationAndThenGet = "UpdateConfigurationAndThenGet";

        public static string GetMealById = "GetMealById";
        public static string GetMealsByRestaurantId = "GetMealsByRestaurantId";
        public static string CreateMeal = "CreateMeal";
        public static string UpdateMeal = "UpdateMeal";
        public static string RemoveMeal = "RemoveMeal";

        public static string CreateRestaurant = "AddRestaurant";
        public static string GetRestaurant = "GetRestaurantById";
        public static string GetRestaurants = "GetRestaurants";
        public static string EditRestaurant = "EditRestaurant";
        public static string RemoveRestaurant = "RemoveRestaurant";

        public static string GetOrders = "GetOrders";
        public static string GetOrderById = "GetOrderById";
        public static string GetOrderPositionsByOrderId = "GetOrderPositionsByOrderId";
        public static string GetOrderPositionsByUserId = "GetOrderPositionsByUserId";



        public static string GetOrderPropositions = "GetOrderPropositions";
        public static string GetOrderPropositionById = "GetOrderPropositionById";
        public static string GetOrderPropositionsInWhichUserHasAvailableOffer = "GetOrderPropositionsInWhichUserHasAvailableOffer";
        public static string CreateOrderProposition = "CreateOrderProposition";



        public static string GetOrderPropositionPositionsByPropositionOrderId = "GetOrderPropositionPositionsByPropositionOrderId";
        public static string CreateOrderPropositionPosition = "CreateOrderPropositionPosition";
        
        

    }
}
