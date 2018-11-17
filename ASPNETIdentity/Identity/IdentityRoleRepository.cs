using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ASPNETIdentity.Identity
{
    public class IdentityRoleRepository : IRoleStore<IdentityRole,int>
    {
        SqlServerRepository repo;
        public IdentityRoleRepository()
        {
            repo = new SqlServerRepository();
        }
        #region IRoleStore
        public Task CreateAsync(IdentityRole role)
        {
            return Task.FromResult(Create(role));
        }
        
        public Task DeleteAsync(IdentityRole role)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityRole> FindByIdAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityRole> FindByIdAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityRole> FindByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IdentityRole role)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region IRoleStore Core
        private int Create(IdentityRole role)
        {
            return repo.Create<IdentityRole>(role);
        }

        #endregion
    }
}