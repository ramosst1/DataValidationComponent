using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationProcess
{
    class FieldInfoDateTimeCompare : FieldInfoBase
    {
        internal DateTime? FieldValue { get; set; }
        internal string FieldCompareName { get; set; }
        internal DateTime? FieldCompareValue { get; set; }

    }
}
