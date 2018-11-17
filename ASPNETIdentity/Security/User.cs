using ASPNETIdentity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ASPNETIdentity.Security
{
    public class User : IdentityUser, IDataErrorInfo
    {
        public bool IsActive { get; set; }

        public string FullName { get; set; }

        public int? CreatedById { get; set; }

        public int? UpdatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public User CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public User UpdatedBy { get; set; }

        #region IDataErrorInfo
        public string this[string columnName] => throw new NotImplementedException();

        public string Error => throw new NotImplementedException();
        #endregion
    }
}