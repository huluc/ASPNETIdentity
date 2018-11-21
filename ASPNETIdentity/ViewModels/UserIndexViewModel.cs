using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETIdentity.ViewModels
{
    public class UserIndexViewModel
    {
        public IEnumerable<UserViewModel> Items { get; set; }

    }
}