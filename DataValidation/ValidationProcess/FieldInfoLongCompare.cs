using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationProcess
{
    class FieldInfoLongCompare : FieldInfoBase
    {
        internal long? FieldValue { get; set; }
        internal string FieldCompareName { get; set; }
        internal long? FieldCompareValue { get; set; }

    }
}
