using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETIdentity
{
    public class BusinessRule
    {
        public string Code { get; set; }
        public string RuleName { get; set; }
        public string Message { get; set; }
        public BusinessRule(string ruleName, string message, string code="")
        {
            Code = code;
            RuleName = ruleName;
            Message = message;
        }
    }
}