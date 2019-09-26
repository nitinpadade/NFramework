using Microsoft.AspNetCore.Mvc;
using NFramework.BL.Contacts;
using NFramework.DTO;
using System;
using System.Security.Claims;

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
            SetLoginUserContext();
            return _query.Execute<TResult, TParameters>(parameters);
        } 

        public TResult Command<TResult, TModel>(TModel cmdObj)
           where TResult : class
           where TModel : class
        {
            SetLoginUserContext();
            return _command.Dispatch<TResult, TModel>(cmdObj);
        }

        public TResultList QueryList<TResultList>()
            where TResultList : class
        {
            SetLoginUserContext();
            return _query.Execute<TResultList>();
        }

        void SetLoginUserContext()
        {
            var result = User.FindFirstValue("UserInfo").Split('|');
            if (result != null)
            {
                LoginUserContext.UserId = Convert.ToInt32(result[0].ToString());
                LoginUserContext.UserName = result[1].ToString();
                LoginUserContext.RoleId = Convert.ToInt32(result[2].ToString());
            }
        }
    }
}