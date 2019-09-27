using NFramework.BL.Contacts;
using NFramework.Data;
using NFramework.DTO;
using NFramework.DTO.Parameters.RefreshLogin;
using NFramework.DTO.QueryModels.UserLogin;
using NFramework.DTO.Result.Query;
using System;
using System.Linq;

namespace NFramework.BL.Query.RefreshLogin
{
    public class RefreshLoginQuery : IQuery<QueryResult<UserLoginModel>, RefreshLoginParameter>
    {
        public readonly NFrameworkDataContext _dataContext;
        public RefreshLoginQuery(NFrameworkDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public QueryResult<UserLoginModel> Execute(RefreshLoginParameter parameters)
        {
            try
            {
                var result = _dataContext.User.Where(n => n.Id == parameters.UserId)
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
