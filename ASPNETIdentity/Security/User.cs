using ASPNETIdentity.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ASPNETIdentity.Security
{
    public class User : IdentityUser, IDataErrorInfo
    {
        public User()
        {

        }
        public User(string userName, string fullName, string email)
        {
            this.UserName = userName;
            this.FullName = fullName;
            this.Email = email;
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User,int> manager )
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            ClaimsIdentity userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("Id", this.Id.ToString()));
            userIdentity.AddClaim(new Claim("FullName", this.FullName ?? ""));
            userIdentity.AddClaim(new Claim("Email", this.Email ?? ""));
            //userIdentity.AddClaim(new Claim("UserName", this.UserName ?? ""));
            userIdentity.AddClaim(new Claim("IsActive", this.IsActive.ToString()));
            return userIdentity;
        }

        public User UpdateRoles(List<IdentityRole> newRoles)
        {
            this.Roles = newRoles;
            return this;
        }

        public bool IsActive { get; set; }

        public string FullName { get; set; }

        public int? CreatedById { get; set; }

        public int? UpdatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public User CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public User UpdatedBy { get; set; }
   
        public string PasswordHash { get; set; }
        /// <summary>
        /// DateTime in UTC when lockout ends, any time in the past is considered not locked out.
        /// </summary>
        public virtual DateTimeOffset? LockoutEnd { get; set; }

        /// <summary>
        /// Is lockout enabled for this user
        /// </summary>
        public virtual bool LockoutEnabled { get; set; }

        /// <summary>
        /// Used to record failures for the purposes of lockout
        /// </summary>
        public virtual int AccessFailedCount { get; set; }

        #region IDataErrorInfo
        public string this[string columnName] => throw new NotImplementedException();

        public string Error => throw new NotImplementedException();
        #endregion
    }
}