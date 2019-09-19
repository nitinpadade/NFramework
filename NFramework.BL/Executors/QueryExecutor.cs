using NFramework.BL.Contacts;
using NFramework.Data;
using System;
using System.Linq;

namespace NFramework.BL.Executors
{
    public class QueryExecutor : IQueryExecutor
    {
        readonly NFrameworkDataContext _dataContext = null;

        public QueryExecutor(NFrameworkDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public TResult Execute<TResult, TParameters>(TParameters parameters)
           where TResult : class
            where TParameters : class
        {

            var interfaceType = typeof(IQuery<TResult, TParameters>);

            var excutingType = AppDomain.CurrentDomain.GetAssemblies()
                                .SelectMany(s => s.GetTypes())
                                .Where(p => interfaceType.IsAssignableFrom(p))
                                .FirstOrDefault();

            var handler = (IQuery<TResult, TParameters>)Activator.CreateInstance(excutingType, _dataContext);

            return handler.Execute(parameters);
        }

        public TResultList Execute<TResultList>() where TResultList : class
        {
            var interfaceType = typeof(IQueryList<TResultList>);

            var excutingType = AppDomain.CurrentDomain.GetAssemblies()
                                .SelectMany(s => s.GetTypes())
                                .Where(p => interfaceType.IsAssignableFrom(p))
                                .FirstOrDefault();

            var handler = (IQueryList<TResultList>)Activator.CreateInstance(excutingType, _dataContext);

            return handler.Execute();
        }
    }
}
