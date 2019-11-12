using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Data.DatabaseInfrastructure;
using Data.Infrastructure.StoredProceduresExecution.Abstract;
using Domain.BusinessObject;
using Domain.Object.Claims;
using Domain.Repositories.Abstract;
using Domain.Repositories.Responses;
using Domain.Updater.Response.Const;

namespace Domain.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly IStoredProceduresExecutor _storedProceduresExecutor;

        public UserRepository(IStoredProceduresExecutor storedProceduresExecutor)
        {
            _storedProceduresExecutor = storedProceduresExecutor;
        }

        public async Task<User> GetUser(Guid id)
        {

            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.GetUserById,
                new List<SqlParameter> {new SqlParameter("@userId", id)});
            User user = ExpandUserFromDataSet(dataSet);
            return user;
        }

        public async Task<User> AddUser(string email, string password)
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.AddUser,
                new List<SqlParameter> {new SqlParameter("@email", email), new SqlParameter("@password", password)});

            return ExpandUserFromDataSet(dataSet);
        }

        public async Task<UserUpdateRepositoryResponse> EditUser(Guid id,string email, string password, bool changePassword = false)
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.EditUser,
                new List<SqlParameter>
                {
                    new SqlParameter("@id",id),new SqlParameter("@email", email), new SqlParameter("@password", changePassword ? password : null)
                });

            if (dataSet.Tables[0].Rows.Contains("Result"))
            {
                return new UserUpdateRepositoryResponse((UserUpdateResponseEnum)dataSet.Tables[0].Rows[0]["Result"],null);
            }

            User user = ExpandUserFromDataSet(dataSet);
            return new UserUpdateRepositoryResponse(UserUpdateResponseEnum.Success,user);
        }


        private static User ExpandUserFromDataSet(DataSet dataSet)
        {
            if (dataSet.Tables[0].Rows.Count == 0) return null;
            DataRow row = dataSet.Tables[0].Rows[0];
            return new User(
                Guid.Parse(row["USR_Id"].ToString()),
                row["USR_Email"].ToString(),
                row["USR_Password"].ToString(),
                DateTime.Parse(row["USR_CreationDate"].ToString()),
                (UserRole)int.Parse(row["USR_Role"].ToString())
                );
        }
    }
}
