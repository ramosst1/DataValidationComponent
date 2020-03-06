using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationProcess
{
    class FieldInfoDoubleCompare : FieldInfoBase
    {
        internal double? FieldValue { get; set; }
        internal string FieldCompareName { get; set; }
        internal double? FieldCompareValue { get; set; }

    }
}
