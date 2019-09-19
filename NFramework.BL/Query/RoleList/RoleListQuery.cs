using NFramework.BL.Contacts;
using NFramework.Data;
using NFramework.DTO;
using NFramework.DTO.QueryModels.RoleList;
using NFramework.DTO.Result.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFramework.BL.Query.RoleList
{
    public class RoleListQuery : IQueryList<QueryResult<RoleListResult>>
    {
        public readonly NFrameworkDataContext _dataContext;
        public RoleListQuery(NFrameworkDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public QueryResult<RoleListResult> Execute()
        {
            try
            {
                var result = _dataContext.Role.Select(n => new RoleListResult { Id = n.Id, Name = n.Name }).ToList();

                return new QueryResult<RoleListResult>
                {
                    DataList = result != null ? result : new List<RoleListResult>(),
                    Message = result != null ? "Query Executed Successfully" : "No Data Present",
                    IsExecuted = true,
                    Status = CommandQueryStatus.Executed
                };

            }
            catch (Exception ex)
            {
                return new QueryResult<RoleListResult>
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
