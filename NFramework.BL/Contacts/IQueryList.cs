using System;
using System.Collections.Generic;
using System.Text;

namespace NFramework.BL.Contacts
{
    public interface IQueryList<TResultList>
    {
        TResultList Execute();
    }
}
