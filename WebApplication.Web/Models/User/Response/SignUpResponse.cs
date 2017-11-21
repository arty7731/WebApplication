using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Web.Models.User.Response
{
    public class SignUpResponse
    {
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SessionId { get; set; }
        public int RoleId { get; set; }
    }
}