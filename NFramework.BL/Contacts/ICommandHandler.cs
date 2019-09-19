using System;
using System.Collections.Generic;
using System.Text;

namespace NFramework.BL.Contacts
{
    public interface ICommandHandler
    {
        TResult Dispatch<TResult, TModel>(TModel cmdObj)
         where TResult : class
          where TModel : class;
    }
}
