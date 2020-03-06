using System.Collections.Generic;

namespace DataValidation.ValidationRules
{
    public interface IRuleConfiguration
    {
        List<IRuleDetail> GetRules();

    }
}