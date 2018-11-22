using ASPNETIdentity.Identity;
using ASPNETIdentity.Security;
using ASPNETIdentity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETIdentity
{
    public static class UserConfig
    {
        public static void RegisterUsers()
        {
            AddUserIfNotExists("user3", "User 3", "user3@gmail.com", RoleNames.User);
        }

        private static void AddUserIfNotExists(string userName, string fullName, string email, string roleName)
        {
            bool isUserNotExists = UserService.Obj.FindByName(userName) == null;
            if (isUserNotExists)
            {
                User user = new User(userName, fullName, email);
                user.UpdateRoles(RoleService.Obj.GetByNames(roleName));
                UserService.Obj.Create(user, "password");
            }
        }
    }
}