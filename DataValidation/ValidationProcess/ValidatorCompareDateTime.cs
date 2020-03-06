using DataValidation.ValidationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataValidation.ValidationProcess
{
    class ValidatorCompareDateTime: IValidatorCompareFieldDateTime
    {
        private IRuleConfiguration RulesConfig;
        private List<IRuleDetail> RuleDetails;
        private List<FieldInfoDateTimeCompare> FieldInfoList = new List<FieldInfoDateTimeCompare>();

        public ValidatorCompareDateTime(IRuleConfiguration ruleConfig)
        {

            RulesConfig = ruleConfig;

            RuleDetails = RulesConfig.GetRules();

        }

        public List<IValidationMessage> Validate() {
            var Messages = new List<IValidationMessage>();

            FieldInfoList.ForEach(delegate (FieldInfoDateTimeCompare aFieldInfo)
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

        public void AddField(string fieldName, DateTime? fieldValue, string fieldCompareName, DateTime? fieldCompareValue, string validationRules)
        {
            FieldInfoList.Add(
                new FieldInfoDateTimeCompare()
                {
                    FieldName = fieldName,
                    FieldValue = fieldValue,
                    FieldCompareName = fieldCompareName,
                    FieldCompareValue = fieldCompareValue,
                    ValidationRules = validationRules.Split(';')
                }
            );
        }

        private static List<IValidationMessage> AreEqual(FieldInfoDateTimeCompare aFieldInfo, IRuleDetail aRuleDetail)
        {

            var Messages = new List<IValidationMessage>();

            var IsValid = true;
            if ((aFieldInfo.FieldValue == null && aFieldInfo.FieldCompareValue == null)) {

                IsValid = true;

                goto FinalResults;
            }

            if ((aFieldInfo.FieldValue == null && aFieldInfo.FieldCompareValue != null) 
                || (aFieldInfo.FieldValue != null && aFieldInfo.FieldCompareValue == null)
            ) {

                IsValid = false;

                goto FinalResults;

            }

            if (DateTime.Compare((DateTime)aFieldInfo.FieldValue, (DateTime)aFieldInfo.FieldCompareValue) != 0)
            {
                IsValid = false;

                goto FinalResults;

            };

            FinalResults:

            if (IsValid == false) {

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

        private static List<IValidationMessage> AreNotEqual(FieldInfoDateTimeCompare aFieldInfo, IRuleDetail aRuleDetail)
        {

            var Messages = new List<IValidationMessage>();

            var IsValid = true;

            if (aFieldInfo.FieldValue == null && aFieldInfo.FieldCompareValue == null)
            {

                IsValid = false;

                goto FinalResults;

            } else if ((aFieldInfo.FieldValue != null && aFieldInfo.FieldCompareValue == null) 
                || (aFieldInfo.FieldValue == null && aFieldInfo.FieldCompareValue != null)
            ) {

                IsValid = true;

                goto FinalResults;

            }

            if (DateTime.Compare((DateTime)aFieldInfo.FieldValue, (DateTime)aFieldInfo.FieldCompareValue) == 0)
            {
                IsValid = false;

                goto FinalResults;

            };

            FinalResults:

            if (IsValid == false)
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

        private static List<IValidationMessage> GreaterThanCompare(FieldInfoDateTimeCompare aFieldInfo, IRuleDetail aRuleDetail) {

            var Messages = new List<IValidationMessage>();

            var IsValid = true;

            if (aFieldInfo.FieldValue == null || aFieldInfo.FieldCompareValue == null)
            {

                IsValid = false;

                goto FinalResults;

            }

            if (DateTime.Compare((DateTime)aFieldInfo.FieldValue, (DateTime)aFieldInfo.FieldCompareValue) <= 0)
            {
                IsValid = false;

                goto FinalResults;

            };

            FinalResults:

            if (IsValid == false)
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

        private static List<IValidationMessage> LessThanCompare(FieldInfoDateTimeCompare aFieldInfo, IRuleDetail aRuleDetail)
        {
            var Messages = new List<IValidationMessage>();

            var IsValid = true;

            if (aFieldInfo.FieldValue == null || aFieldInfo.FieldCompareValue == null)
            {

                IsValid = false;

                goto FinalResults;

            }

            if (DateTime.Compare((DateTime)aFieldInfo.FieldValue, (DateTime)aFieldInfo.FieldCompareValue) >= 0)
            {
                IsValid = false;

                goto FinalResults;

            };

            FinalResults:

            if (IsValid == false)
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
