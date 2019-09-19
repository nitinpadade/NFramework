using System;
using System.Collections.Generic;
using System.Text;

namespace NFramework.DTO.QueryModels.UserLogin
{
    public class UserLoginResult
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public int? RoleId { get; set; }

        public string RoleName { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}
