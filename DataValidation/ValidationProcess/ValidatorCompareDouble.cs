using DataValidation.ValidationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataValidation.ValidationProcess
{
    class ValidatorCompareDouble: IValidatorCompareFieldDouble
    {
        private IRuleConfiguration RulesConfig;
        private List<IRuleDetail> RuleDetails;
        private List<FieldInfoDoubleCompare> FieldInfoList = new List<FieldInfoDoubleCompare>();

        public ValidatorCompareDouble(IRuleConfiguration ruleConfig)
        {

            RulesConfig = ruleConfig;

            RuleDetails = RulesConfig.GetRules();

        }

        public List<IValidationMessage> Validate() {
            var Messages = new List<IValidationMessage>();

            FieldInfoList.ForEach(delegate (FieldInfoDoubleCompare aFieldInfo)
            {
                foreach (var aRule in aFieldInfo.ValidationRules)
                {

                    IRuleDetail ARuleDetail;

                    ARuleDetail = RuleDetails.FirstOrDefault(
                        aItem => aItem.Rule.Equals(aRule.Trim(), StringComparison.CurrentCultureIgnoreCase)
                    );

                    switch (aRule.Trim())
                    {
                        case "AreEqual":

                            Messages.AddRange(AreEqual(aFieldInfo, ARuleDetail));
                            break;
                        case "AreNotEqual":

                            Messages.AddRange(AreNotEqual(aFieldInfo, ARuleDetail));
                            break;
                        case "GreaterThanCompare":

                            Messages.AddRange(GreaterThanCompare(aFieldInfo, ARuleDetail));
                            break;
                        case "LessThanCompare":

                            Messages.AddRange(LessThanCompare(aFieldInfo, ARuleDetail));
                            break;


                    };
                }

            });

            return Messages;

        }

        public void AddField(string fieldName, double? fieldValue, string fieldCompareName, double? fieldCompareValue, string validationRules)
        {
            FieldInfoList.Add(
                new FieldInfoDoubleCompare()
                {
                    FieldName = fieldName,
                    FieldValue = fieldValue,
                    FieldCompareName = fieldCompareName,
                    FieldCompareValue = fieldCompareValue,
                    ValidationRules = validationRules.Split(';')
                }
            );
        }

        private static List<IValidationMessage> AreEqual(FieldInfoDoubleCompare aFieldInfo, IRuleDetail aRuleDetail)
        {

            var Messages = new List<IValidationMessage>();

            if (aFieldInfo.FieldValue != aFieldInfo.FieldCompareValue)
            {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message
                    .Replace("{FieldNameCompare}", aFieldInfo.FieldCompareName)
                    .Replace("{FieldName}", aFieldInfo.FieldName)
                    ,
                    FieldName = aFieldInfo.FieldName
                });
            };

            return Messages;

        }

        private static List<IValidationMessage> AreNotEqual(FieldInfoDoubleCompare aFieldInfo, IRuleDetail aRuleDetail)
        {

            var Messages = new List<IValidationMessage>();

            if (aFieldInfo.FieldValue == aFieldInfo.FieldCompareValue)
            {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message
                    .Replace("{FieldNameCompare}", aFieldInfo.FieldCompareName)
                    .Replace("{FieldName}", aFieldInfo.FieldName)
                    ,
                    FieldName = aFieldInfo.FieldName
                });
            };

            return Messages;

        }

        private static List<IValidationMessage> GreaterThanCompare(FieldInfoDoubleCompare aFieldInfo, IRuleDetail aRuleDetail) {
            var Messages = new List<IValidationMessage>();

            var IsDataValid = true;

            if (aFieldInfo.FieldValue == null || aFieldInfo.FieldCompareValue == null) {
                IsDataValid = false;
                goto FinalResults;
            }

            if (aFieldInfo.FieldValue <= aFieldInfo.FieldCompareValue)
            {
                IsDataValid = false;
                goto FinalResults;

            };

            FinalResults:

            if (IsDataValid == false) {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message
                    .Replace("{FieldNameCompare}", aFieldInfo.FieldCompareName)
                    .Replace("{FieldName}", aFieldInfo.FieldName)
                    ,
                    FieldName = aFieldInfo.FieldName
                });

            }


                return Messages;

        }

        private static List<IValidationMessage> LessThanCompare(FieldInfoDoubleCompare aFieldInfo, IRuleDetail aRuleDetail)
        {
            var Messages = new List<IValidationMessage>();

            var IsDataValid = true;

            if (aFieldInfo.FieldValue == null || aFieldInfo.FieldCompareValue == null)
            {
                IsDataValid = false;
                goto FinalResults;
            }

            if (aFieldInfo.FieldValue >= aFieldInfo.FieldCompareValue)
            {
                IsDataValid = false;
                goto FinalResults;

            };

            FinalResults:

            if (IsDataValid == false)
            {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message
                    .Replace("{FieldNameCompare}", aFieldInfo.FieldCompareName)
                    .Replace("{FieldName}", aFieldInfo.FieldName)
                    ,
                    FieldName = aFieldInfo.FieldName
                });

            }


            return Messages;

        }
    }
}
