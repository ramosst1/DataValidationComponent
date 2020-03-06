using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationProcess
{
    interface IValidatorCompareFieldString: IValidatorBase
    {
        void AddField(string fieldName, string fieldValue, string fieldCompareName, string fieldCompareValue, string validationRules);

    }
}
