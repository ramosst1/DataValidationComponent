using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationProcess
{
    interface IValidatorSingleFieldLong: IValidatorBase
    {
        void AddField(string fieldName, long? fieldValue, string validationRules);

    }
}
