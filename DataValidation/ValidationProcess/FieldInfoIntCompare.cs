using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationProcess
{
    class FieldInfoIntCompare : FieldInfoBase
    {
        internal int? FieldValue { get; set; }
        internal string FieldCompareName { get; set; }
        internal int? FieldCompareValue { get; set; }

    }
}
