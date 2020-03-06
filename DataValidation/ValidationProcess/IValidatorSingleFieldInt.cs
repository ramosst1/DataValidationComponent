using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationProcess
{
    interface IValidatorSingleFieldInt: IValidatorBase
    {
        void AddField(string fieldName, int? fieldValue, string validationRules);

    }
}
