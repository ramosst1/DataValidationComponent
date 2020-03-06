using System.Collections.Generic;

namespace DataValidation.ValidationProcess
{
    interface IValidatorBase
    {
        List<IValidationMessage> Validate();
    }
}