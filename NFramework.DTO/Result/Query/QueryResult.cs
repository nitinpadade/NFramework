using System;
using System.Collections.Generic;
using System.Text;

namespace NFramework.DTO.Result.Query
{
    public class QueryResult<T>
    {
        public T Data { get; set; }

        public List<T> DataList { get; set; }

        public int TotalCount { get; set; }

        public double TotalPages { get; set; }

        public bool IsExecuted { get; set; }

        public string Message { get; set; }

        public string ErrorMessage { get; set; }

        public CommandQueryStatus Status { get; set; }
    }
}
