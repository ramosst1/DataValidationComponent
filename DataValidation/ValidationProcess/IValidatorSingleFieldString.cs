using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationProcess
{
    interface IValidatorSingleFieldString: IValidatorBase
    {
        void AddField(string fieldName, string fieldValue , string validationRules);

    }
}
