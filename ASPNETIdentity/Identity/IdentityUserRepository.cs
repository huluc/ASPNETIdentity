using ASPNETIdentity.Security;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ASPNETIdentity.Identity
{
    public class IdentityUserRepository : IUserStore<User, int>
    {
        SqlServerRepository repository;
        public IdentityUserRepository()
        {
            repository = new SqlServerRepository();
        }
        #region IUserStore
        public Task CreateAsync(User user)
        {
            return Task.FromResult(Create(user));
        }

  

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(int userId)
        {
            if (userId == 0)
                throw new ArgumentNullException("userID", "must not be null.");
            return Task.FromResult(repository.Get<User>(x => x.Id == userId));
        }

        public Task<User> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IUserStore (Core)
        private int Create(User user)
        {
            return repository.Create<User>(user);
        }
        #endregion

    }
}