using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.ValidationProcess
{
    internal class FieldInfoStringCompare: FieldInfoBase
    {
        internal string FieldValue { get; set; }
        internal string FieldCompareName { get; set; }
        internal string FieldCompareValue { get; set; }

    }
}
