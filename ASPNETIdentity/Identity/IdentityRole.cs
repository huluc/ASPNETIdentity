using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace ASPNETIdentity.Identity
{
    public class IdentityRole : IRole<int>
    {
        public IdentityRole()
        {
            Claims = new List<IdentityRoleClaim>();
            Users = new List<IdentityUser>();
        }
        public IdentityRole(string roleName) : this()
        {
            Name = roleName;
        }
        public virtual int Id { get; set; }

        public virtual string Name { get; set ; }

        public virtual string NormalizedName { get; set; }

        public virtual List<IdentityUser> Users { get; set; }

        public virtual ICollection<IdentityRoleClaim> Claims { get; set; }

    }
}