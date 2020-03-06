using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationRules
{
    class RuleDetail : IRuleDetail
    {
        public string Rule { get; set; }
        public string Message { get; set; }

    }
}
