using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationProcess
{
    interface IValidatorCompareFieldDouble: IValidatorBase
    {
        void AddField(string fieldName, double? fieldValue, string fieldCompareName, double? fieldCompareValue, string validationRules);

    }
}
