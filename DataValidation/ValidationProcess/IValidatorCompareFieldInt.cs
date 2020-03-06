using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationProcess
{
    interface IValidatorCompareFieldInt: IValidatorBase
    {
        void AddField(string fieldName, int? fieldValue, string fieldCompareName, int? fieldCompareValue, string validationRules);

    }
}
