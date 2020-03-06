using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationRules
{
    public class RuleDetailJson : IRuleDetail
    {
        public string Message { get ; set; }
        public string Rule { get ; set ; }
    }
}
