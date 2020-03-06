using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationProcess
{
    interface IValidatorSingleFieldDouble: IValidatorBase
    {
        void AddField(string fieldName, double? fieldValue, string validationRules);

    }
}
