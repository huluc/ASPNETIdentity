using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace ASPNETIdentity.Identity
{
    public class IdentityUser : IUser<int>
    {
        public IdentityUser()
        {
            Roles = new List<IdentityRole>();
            IdentityUserClaims = new List<IdentityUserClaim>();
            IdentityUserLogins = new List<IdentityUserLogin>();
        }
        public int Id { get; set; }

        public string UserName { get; set ; }

        public string Email { get; set; }
        public bool EmilConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactorEnabled { get; set; }

        public virtual ICollection<IdentityRole> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim> IdentityUserClaims { get; set; }

        public virtual ICollection<IdentityUserLogin> IdentityUserLogins { get; set; }
    }
}