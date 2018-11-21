using ASPNETIdentity.Security;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETIdentity.Identity
{
    public interface IIdentityUserRepository : IUserStore<User, int>
        , IUserPasswordStore<User, int>
         , IUserLockoutStore<User, int>
    //,IUserEmailStore<User, int>
    , IUserTwoFactorStore<User, int>
    //,IUserRoleStore<User, int>
    //,IUserTokenProvider<User, int>
    //IUserLoginStore<User, int>
    {
    }
}
