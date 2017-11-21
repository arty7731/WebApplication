using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Core.Enums;

namespace WebApplication.Web.Attributes
{
    public class WebAuthorizeAttribute: AuthorizeAttribute
    {
        public RoleType[] AllowedRoles;

        public WebAuthorizeAttribute()
        { }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = AllowedRoles?.Count() > 0
                ? UserMng.Current.IsSignIn && AllowedRoles.Any(r => r == UserMng.Current.Role)
                : UserMng.Current.IsSignIn;

            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}