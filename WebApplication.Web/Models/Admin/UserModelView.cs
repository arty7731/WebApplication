using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Core.Enums;

namespace WebApplication.Web.Models.Admin
{
    public class UserModelView
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}