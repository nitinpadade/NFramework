using NFramework.BL.Contacts;
using NFramework.Data;
using NFramework.DTO;
using NFramework.DTO.Parameters.UserLogin;
using NFramework.DTO.QueryModels.UserLogin;
using NFramework.DTO.Result.Query;
using System;
using System.Linq;

namespace NFramework.BL.Query.UserLogin
{
    public class UserLoginQuery : IQuery<QueryResult<UserLoginModel>, UserLoginParameter>
    {
        public readonly NFrameworkDataContext _dataContext;
        public UserLoginQuery(NFrameworkDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public QueryResult<UserLoginModel> Execute(UserLoginParameter parameters)
        {
            try
            {
                var result = _dataContext.User.Where(n => n.UserName == parameters.UserName && n.Password == parameters.Password)
                       .Select(n => new UserLoginModel
                       {
                           IsAuthenticated = true,
                           Name = n.FirstName + " " + n.LastName,
                           RoleId = n.RoleId,
                           UserId = n.Id
                       }).FirstOrDefault();

                return new QueryResult<UserLoginModel>
                {
                    Data = result != null ? result : new UserLoginModel(),
                    Message = result != null ? "Query Executed Successfully" : "No Data Present",
                    IsExecuted = true,
                    Status = CommandQueryStatus.Executed
                };

            }
            catch (Exception ex)
            {
                return new QueryResult<UserLoginModel>
                {
                    Data = null,
                    Message = "Error While Executing Query",
                    IsExecuted = false,
                    Status = CommandQueryStatus.Failed,
                    ErrorMessage = ex.ToString()
                };
            }
        }
    }
}
