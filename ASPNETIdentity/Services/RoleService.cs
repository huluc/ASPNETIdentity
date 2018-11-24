using ASPNETIdentity.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETIdentity.Services
{
    public class RoleService :RoleManager<IdentityRole,int>
    {
        SqlServerRepository repo = new SqlServerRepository();
        public static RoleService Obj;
        static RoleService()
        {
            IRoleStore<IdentityRole,int> roleStore = new IdentityRoleRepository();
            Obj = new RoleService(roleStore);
        }
        public RoleService(IRoleStore<IdentityRole,int> roleStore):base(roleStore)
        {

        }
        public List<IdentityRole> GetByNames(params string[] roleNames)
        {
            //Constraint avantajı
            List<IdentityRole> roles = repo.GetAll<IdentityRole>(x => roleNames.Contains(x.Name));
            return roles;
        }
        public IdentityRole FindByName(string roleName)
        {
            IdentityRole role = repo.Get<IdentityRole>(x => x.Name == roleName);
            return role;
        }
        public void Create(IdentityRole role)
        {
            repo.Create<IdentityRole>(role);
        }
    }
}