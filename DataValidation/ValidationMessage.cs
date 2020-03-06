using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation
{
    public class ValidationMessage : IValidationMessage
    {
        public string ErrorMessage { get;  set; }
        public string FieldName { get; set; }

    }
}
