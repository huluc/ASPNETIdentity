using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace ASPNETIdentity.Identity
{
    public class IdentityRole : IRole<int>
    {
        public IdentityRole()
        {
            IdentityRoleClaims = new List<IdentityRoleClaim>();
        }
        public int Id { get; set; }

        public string Name { get; set ; }

        public ICollection<IdentityRoleClaim> IdentityRoleClaims { get; set; }

    }
}