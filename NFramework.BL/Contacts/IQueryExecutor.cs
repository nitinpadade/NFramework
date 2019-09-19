using System;
using System.Collections.Generic;
using System.Text;

namespace NFramework.BL.Contacts
{
    public interface IQueryExecutor
    {
        TResult Execute<TResult, TParameters>(TParameters parameters)
          where TResult : class
           where TParameters : class;

        TResultList Execute<TResultList>()
          where TResultList : class;
    }
}
