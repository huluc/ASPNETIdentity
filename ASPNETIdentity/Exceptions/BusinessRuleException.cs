using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace ASPNETIdentity.Exceptions
{
    public class BusinessRuleException :Exception
    {
        public BusinessRuleException(string entityName, BusinessRule businessRule,[CallerMemberName] string businessOperation ="")
        {
            Rule = businessRule;
            RuleName = businessOperation + businessRule.RuleName;
            EntityName = entityName;
        }
        public BusinessRuleExceptionType Type { get; private set; }
        public string RuleName { get; private set; }
        public BusinessRule Rule { get; private set; }
        public string EntityName { get; set; }
        
    }
    
    public enum BusinessRuleExceptionType
    {
        General,
        NotFound,
    }
}