using NFramework.BL.Contacts;
using NFramework.Data;
using System;
using System.Linq;

namespace NFramework.BL.Handlers
{
    public class CommandHandler : ICommandHandler
    {
        readonly NFrameworkDataContext _dataContext = null;

        public CommandHandler(NFrameworkDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public TResult Dispatch<TResult, TModel>(TModel cmdObj)
            where TResult : class
            where TModel : class
        {
            var interfaceType = typeof(ICommand<TResult, TModel>);

            var excutingType = AppDomain.CurrentDomain.GetAssemblies()
                                .SelectMany(s => s.GetTypes())
                                .Where(p => interfaceType.IsAssignableFrom(p))
                                .FirstOrDefault();

            var handler = (ICommand<TResult, TModel>)Activator.CreateInstance(excutingType, _dataContext);

            return handler.Dispatch(cmdObj);
        }
    }
}
