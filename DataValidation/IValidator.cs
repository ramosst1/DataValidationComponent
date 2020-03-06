using System;
using System.Collections.Generic;

namespace DataValidation
{
    public interface IValidator
    {
        void AddField(string fieldName, DateTime? fieldValue, string fieldCompareName, DateTime? fieldCompareValue, string validationRules);
        void AddField(string fieldName, double? fieldValue, string validationRules);
        void AddField(string fieldName, double? fieldValue, string fieldCompareName, double? fieldCompareValue, string validationRules);
        void AddField(string fieldName, int? fieldValue, string validationRules);
        void AddField(string fieldName, int? fieldValue, string fieldCompareName, int? fieldCompareValue, string validationRules);
        void AddField(string fieldName, long? fieldValue, string validationRules);
        void AddField(string fieldName, long? fieldValue, string fieldCompareName, long? fieldCompareValue, string validationRules);
        void AddField(string fieldName, string fieldValue, string validationRules);
        void AddField(string fieldName, string fieldValue, string fieldCompareName, string fieldCompareValue, string validationRules);
        List<IValidationMessage> Validate();
    }
}