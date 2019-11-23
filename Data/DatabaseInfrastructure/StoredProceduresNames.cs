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
        public static string GetConfiguration = "GetConfiguration";
        public static string UpdateConfigurationAndThenGet = "UpdateConfigurationAndThenGet";
    }
}
