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
using Domain.Object.Claims;
using Domain.Repositories.Abstract;
using Domain.Repositories.Responses;
using Domain.Updater.Response.Const;

namespace Domain.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly IStoredProceduresExecutor _storedProceduresExecutor;
        private readonly IDataRowToObjectMapper _dataRowToObjectMapper;

        public UserRepository(IStoredProceduresExecutor storedProceduresExecutor, IDataRowToObjectMapper dataRowToObjectMapper)
        {
            _storedProceduresExecutor = storedProceduresExecutor;
            _dataRowToObjectMapper = dataRowToObjectMapper;
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


        private User ExpandUserFromDataSet(DataSet dataSet)
        {
            DataRow dataRow = dataSet.Tables[0].Rows.Count == 0 ? null : dataSet.Tables[0].Rows[0];
            return _dataRowToObjectMapper.ConvertUser(dataRow);
        }
    }
}
