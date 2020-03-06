using System;
using System.Collections.Generic;
using System.Linq;
using DataValidation.ValidationRules;
using DataValidation.ValidationProcess;

namespace DataValidation
{
    public class Validator : IValidator
    {

        private IRuleConfiguration RuleConfig;

        private List<IValidatorBase> ValidationList = new List<IValidatorBase>();

        public Validator()
        {


            RuleConfig = new RuleConfiguration();

        }
        public List<IValidationMessage> Validate()
        {

            var Messages = new List<IValidationMessage>();

            ValidationList.ForEach(delegate (IValidatorBase aValidator) {

                Messages.AddRange(aValidator.Validate());

            });

            return Messages;
        }

        public void AddField(string fieldName, string fieldValue, string validationRules)
        {
            IValidatorSingleFieldString  AValidate = new ValidationProcess.ValidatorSingleString(RuleConfig);

            AValidate.AddField(fieldName, fieldValue, validationRules);

            ValidationList.Add(AValidate);

        }
        public void AddField(string fieldName, string fieldValue, string fieldCompareName, string fieldCompareValue, string validationRules)
        {
            IValidatorCompareFieldString AValidate = new ValidationProcess.ValidatorCompareString(RuleConfig);

            AValidate.AddField(fieldName, fieldValue, fieldCompareName,fieldCompareValue, validationRules);

            ValidationList.Add(AValidate);

        }
        public void AddField(string fieldName, int? fieldValue, string validationRules)
        {

            IValidatorSingleFieldInt AValidate = new ValidationProcess.ValidatorSingleInt(RuleConfig);

            AValidate.AddField(fieldName, fieldValue, validationRules);

            ValidationList.Add(AValidate);

        }
        public void AddField(string fieldName, int? fieldValue, string fieldCompareName, int? fieldCompareValue, string validationRules)
        {
            IValidatorCompareFieldInt AValidate = new ValidationProcess.ValidatorCompareInt(RuleConfig);

            AValidate.AddField(fieldName, fieldValue, fieldCompareName, fieldCompareValue, validationRules);

            ValidationList.Add(AValidate);

        }
        public void AddField(string fieldName, double? fieldValue, string validationRules)
        {

            IValidatorSingleFieldDouble AValidate = new ValidationProcess.ValidatorSingleDouble(RuleConfig);

            AValidate.AddField(fieldName, fieldValue, validationRules);

            ValidationList.Add(AValidate);

        }
        public void AddField(string fieldName, double? fieldValue, string fieldCompareName, double? fieldCompareValue, string validationRules)
        {
            IValidatorCompareFieldDouble AValidate = new ValidationProcess.ValidatorCompareDouble(RuleConfig);

            AValidate.AddField(fieldName, fieldValue, fieldCompareName, fieldCompareValue, validationRules);

            ValidationList.Add(AValidate);

        }
        public void AddField(string fieldName, long? fieldValue, string validationRules)
        {

            IValidatorSingleFieldLong AValidate = new ValidationProcess.ValidatorSingleLong(RuleConfig);

            AValidate.AddField(fieldName, fieldValue, validationRules);

            ValidationList.Add(AValidate);

        }
        public void AddField(string fieldName, long? fieldValue, string fieldCompareName, long? fieldCompareValue, string validationRules)
        {
            IValidatorCompareFieldLong AValidate = new ValidationProcess.ValidatorCompareLong(RuleConfig);

            AValidate.AddField(fieldName, fieldValue, fieldCompareName, fieldCompareValue, validationRules);

            ValidationList.Add(AValidate);

        }
        public void AddField(string fieldName, DateTime? fieldValue, string fieldCompareName, DateTime? fieldCompareValue, string validationRules)
        {
            IValidatorCompareFieldDateTime AValidate = new ValidationProcess.ValidatorCompareDateTime(RuleConfig);

            AValidate.AddField(fieldName, fieldValue, fieldCompareName, fieldCompareValue, validationRules);

            ValidationList.Add(AValidate);

        }

    }
}
