using DataValidation.ValidationRules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataValidation.ValidationProcess
{
    class ValidatorCompareString : IValidatorCompareFieldString
    {

        private IRuleConfiguration RulesConfig;
        private List<IRuleDetail> RuleDetails;
        private List<FieldInfoStringCompare> FieldInfoList = new List<FieldInfoStringCompare>();

        public ValidatorCompareString(IRuleConfiguration ruleConfig)
        {

            RulesConfig = ruleConfig;

            RuleDetails = RulesConfig.GetRules();

        }

        public void AddField(string fieldName, string fieldValue, string fieldCompareName,string fieldCompareValue, string validationRules)
        {
            FieldInfoList.Add(
                new FieldInfoStringCompare()
                {
                    FieldName = fieldName,
                    FieldValue = fieldValue,
                    FieldCompareName = fieldCompareName,
                    FieldCompareValue = fieldCompareValue,
                    ValidationRules = validationRules.Split(';')
                }
            );
        }

        public List<IValidationMessage> Validate()
        {

            var Messages = new List<IValidationMessage>();

            FieldInfoList.ForEach(delegate (FieldInfoStringCompare aFieldInfo)
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

                        case "Exact":

                            Messages.AddRange(Exact(aFieldInfo, ARuleDetail));
                            break;
                        case "NotExact":

                            Messages.AddRange(NotExact(aFieldInfo, ARuleDetail));
                            break;
                    }

                };


            });

            return Messages;
        }

        private static List<IValidationMessage> AreEqual(FieldInfoStringCompare aFieldInfo, IRuleDetail aRuleDetail)
        {

            var Messages = new List<IValidationMessage>();

            if (String.Compare(aFieldInfo.FieldValue,aFieldInfo.FieldCompareValue,true) != 0)
            {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message
                    .Replace("{FieldNameCompare}", aFieldInfo.FieldCompareName)
                    .Replace("{FieldName}", aFieldInfo.FieldName)
                    ,FieldName = aFieldInfo.FieldName
                });
            };

            return Messages;

        }

        private static List<IValidationMessage> AreNotEqual(FieldInfoStringCompare aFieldInfo, IRuleDetail aRuleDetail)
        {

            var Messages = new List<IValidationMessage>();

            if (String.Compare(aFieldInfo.FieldValue, aFieldInfo.FieldCompareValue, true) == 0)
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

        private static List<IValidationMessage> Exact(FieldInfoStringCompare aFieldInfo, IRuleDetail aRuleDetail)
        {

            var Messages = new List<IValidationMessage>();

            if (String.Compare(aFieldInfo.FieldValue, aFieldInfo.FieldCompareValue, false) != 0)
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

        private static List<IValidationMessage> NotExact(FieldInfoStringCompare aFieldInfo, IRuleDetail aRuleDetail)
        {

            var Messages = new List<IValidationMessage>();

            if (String.Compare(aFieldInfo.FieldValue, aFieldInfo.FieldCompareValue, false) == 0)
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
    }
}
