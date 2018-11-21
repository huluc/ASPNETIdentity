using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace ASPNETIdentity.Identity
{
    public class IdentityRole : IRole<int>
    {
        public IdentityRole()
        {
            Claims = new List<IdentityRoleClaim>();
        }
        public IdentityRole(string roleName) : this()
        {
            Name = roleName;
        }
        public int Id { get; set; }

        public string Name { get; set ; }

        public string NormalizedName { get; set; }

        public ICollection<IdentityUser> Users { get; set; }

        public ICollection<IdentityRoleClaim> Claims { get; set; }

    }
}