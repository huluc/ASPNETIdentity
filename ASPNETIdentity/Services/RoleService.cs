using ASPNETIdentity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETIdentity.Services
{
    public class RoleService 
    {
        SqlServerRepository repo = new SqlServerRepository();
        public static RoleService Obj;
        static RoleService()
        {
            Obj = new RoleService();
        }
        private RoleService()
        {

        }
        public List<IdentityRole> GetByNames(params string[] roleNames)
        {
            //Constraint avantajı
            List<IdentityRole> roles = repo.GetAll<IdentityRole>(x => roleNames.Contains(x.Name));
            return roles;
        }
    }
}