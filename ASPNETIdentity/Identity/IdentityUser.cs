using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public virtual int Id { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Email { get; set; }
        public virtual bool EmilConfirmed { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }

        public virtual List<IdentityRole> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim> IdentityUserClaims { get; set; }

        public virtual ICollection<IdentityUserLogin> IdentityUserLogins { get; set; }
    }
}