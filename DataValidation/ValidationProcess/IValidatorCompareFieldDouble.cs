using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationProcess
{
    interface IValidatorCompareFieldLong: IValidatorBase
    {
        void AddField(string fieldName, long? fieldValue, string fieldCompareName, long? fieldCompareValue, string validationRules);

    }
}
