using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Core.Enums;

namespace WebApplication.Web
{
    public class UserMng
    {
        // private constructor
        private UserMng()
        {
        }

        // Gets the current session.
        public static UserMng Current
        {
            get
            {
                UserMng session =
                  (UserMng)HttpContext.Current.Session["__User__"];
                if (session == null)
                {
                    session = new UserMng();
                    HttpContext.Current.Session["__User__"] = session;
                }
                return session;
            }
        }

        public string FullName { get; set; }
        public string Nickname { get; set; }
        public RoleType Role { get; set; }
        public bool IsAdmin { get; set; }
        public string Email { get; set; }
        public bool IsSignIn { get; set; }
        public int Id { get; set; }

        public static void Clear()
        {
            HttpContext.Current.Session.Remove("__User__");
        }
    }
}