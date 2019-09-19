using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NFramework.BL.Contacts;

namespace NFramework.RS.Controllers
{
   
    public class BaseController : ControllerBase
    {
        readonly IQueryExecutor _query;
        readonly ICommandHandler _command;
        public BaseController(IQueryExecutor query, ICommandHandler command)
        {
            _query = query;
            _command = command;
        }

        public TResult Query<TResult, TParameters>(TParameters parameters)
           where TResult : class
            where TParameters : class
        {

           return _query.Execute<TResult, TParameters>(parameters);
        }

        public TResult Command<TResult, TModel>(TModel cmdObj)
           where TResult : class
           where TModel : class
        {
            return _command.Dispatch<TResult, TModel>(cmdObj);
        }

        public TResultList QueryList<TResultList>() 
            where TResultList : class
        {
            return _query.Execute<TResultList>();
        }
    }
}