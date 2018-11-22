using ASPNETIdentity.Identity;
using ASPNETIdentity.Security;
using ASPNETIdentity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETIdentity.Components
{
    public class RolesAttribute: AuthorizeAttribute
    {
        public RolesAttribute(params string[] roles)
        {
            Roles = string.Join(",", roles);
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                User user = UserService.Obj.FindByName(filterContext.HttpContext.User.Identity.Name);
                if (user?.IsActive == false)
                {
                    HandleUnauthorizedRequest(filterContext);
                    return;
                }
            }
        }
    }

    public class AllowAdminAttribute : RolesAttribute
    {
        public AllowAdminAttribute()
            : base(RoleNames.Admin)
        {
        }
    }
}