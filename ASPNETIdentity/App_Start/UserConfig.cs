using ASPNETIdentity.Identity;
using ASPNETIdentity.Security;
using ASPNETIdentity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ASPNETIdentity
{
    public static class UserConfig
    {
        public static void RegisterUsers()
        {
            AddUserIfNotExists("user6", "User 6", "user6@gmail.com", RoleNames.User);
        }

        private static void AddUserIfNotExists(string userName, string fullName, string email, string roleName)
        {
            bool isUserNotExists = UserService.Obj.FindByName(userName) == null;
            if (isUserNotExists)
            {
                User user = new User(userName, fullName, email);
                var role = RoleService.Obj.FindByName(roleName);
                if(role == null)
                {
                    role = new IdentityRole()
                    {
                        Name = roleName
                    };
                   
                    RoleService.Obj.Create(role);
                }
                user.UpdateRoles(RoleService.Obj.GetByNames(roleName));
                UserService.Obj.Create(user, "password");
            
                
                var rolesForUser = UserService.Obj.GetRoles(user);

                if (!rolesForUser.Contains(role.Name))
                {
                    var result = UserService.Obj.AddToRoleAsync(user.Id, role.Name);

                }

             

            }
        }
    }
}