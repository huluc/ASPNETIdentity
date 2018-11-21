using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETIdentity
{
    public class BusinessRules
    {
        public static readonly BusinessRule UsedEmail = new BusinessRule(nameof(UsedEmail), "Eposta zeten mevcut!", "001");
    }
}