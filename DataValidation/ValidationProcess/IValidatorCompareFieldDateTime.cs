using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationProcess
{
    interface IValidatorCompareFieldDateTime: IValidatorBase
    {
        void AddField(string fieldName, DateTime? fieldValue, string fieldCompareName, DateTime? fieldCompareValue, string validationRules);

    }
}
