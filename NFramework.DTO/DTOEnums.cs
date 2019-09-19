using System;
using System.Collections.Generic;
using System.Text;

namespace NFramework.DTO
{
    class DTOEnums
    {
    }

    public enum CommandQueryStatus
    {
        Default = 0,
        Executed,
        Failed,
        Warning,
        AccessDenied
    }
}
