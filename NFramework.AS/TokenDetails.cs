using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFramework.AS
{
    public class TokenDetails
    {
        public int UserId { get; set; }

        public string User { get; set; }

        public string Token { get; set; }

        public int RoleId { get; set; }

        public bool IsAuthenticated { get; set; }

    }
}
