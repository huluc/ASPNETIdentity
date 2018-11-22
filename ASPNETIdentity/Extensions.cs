using ASPNETIdentity.Security;
using ASPNETIdentity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace ASPNETIdentity
{
    public static class Extensions
    {
        public static User GetCurrentUser()
        {
            return UserService.Obj.FindByName(Thread.CurrentPrincipal.Identity.Name);
        }
        private static  SqlServerRepository queryRepository= new SqlServerRepository();
        public static bool IsUsedEmail(this User user)
        {
            User founded = queryRepository.Get<User>(x => x.UserName == user.UserName);
            return founded != null;
        }
    }
}