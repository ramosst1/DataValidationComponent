using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationProcess
{
    internal class FieldInfoBase
    {
        internal string[] ValidationRules { get; set; } = new string[0];
        internal string FieldName { get; set; }

    }
}
