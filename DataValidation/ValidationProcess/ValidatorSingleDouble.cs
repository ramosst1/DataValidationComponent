using DataValidation.ValidationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataValidation.ValidationProcess
{
    class ValidatorSingleDouble: IValidatorSingleFieldDouble
    {
        private IRuleConfiguration RulesConfig;

        private List<IRuleDetail> RuleDetails;

        List<FieldInfoDouble> FieldInfoList = new List<FieldInfoDouble>();

        public ValidatorSingleDouble(IRuleConfiguration ruleConfig)
        {
            RulesConfig = ruleConfig;

            RuleDetails = RulesConfig.GetRules();

        }

        public List<IValidationMessage> Validate()
        {

            var Messages = new List<IValidationMessage>();

            FieldInfoList.ForEach(delegate (FieldInfoDouble aFieldInfo)
            {
                foreach (var aRule in aFieldInfo.ValidationRules)
                {
                    
                    IRuleDetail ARuleDetail;

                    ARuleDetail = RuleDetails.FirstOrDefault(
                        aItem => aItem.Rule.Equals(aRule.Trim(), StringComparison.CurrentCultureIgnoreCase)
                    );

                    switch (aRule)
                    {
                        case "Required":

                            Messages.AddRange(Required(aFieldInfo, ARuleDetail));
                            break;
                    }

                    if (aRule.StartsWith("GreaterThan"))
                    {

                        ARuleDetail = RuleDetails.Where(aItem => aItem.Rule.StartsWith("GreaterThan")).FirstOrDefault();

                        var GreaterThanNumberStr = aRule.Substring(12).Replace(")", "");

                        var GreaterThanNumber = int.Parse(GreaterThanNumberStr);

                        Messages.AddRange(GreaterThan(aFieldInfo, GreaterThanNumber, ARuleDetail));

                    }

                    if (aRule.StartsWith("LessThan"))
                    {

                        ARuleDetail = RuleDetails.Where(aItem => aItem.Rule.StartsWith("LessThan")).FirstOrDefault();

                        var LessThanNumberStr = aRule.Substring(9).Replace(")", "");

                        var LessThanNumber = int.Parse(LessThanNumberStr);

                        Messages.AddRange(LessThan(aFieldInfo, LessThanNumber, ARuleDetail));

                    }

                    if (aRule.StartsWith("Equal"))
                    {

                        ARuleDetail = RuleDetails.Where(aItem => aItem.Rule.StartsWith("Equal")).FirstOrDefault();

                        var EqualNumberStr = aRule.Substring(6).Replace(")", "");

                        var EqualNumber = int.Parse(EqualNumberStr);

                        Messages.AddRange(Equal(aFieldInfo, EqualNumber, ARuleDetail));

                    }

                    if (aRule.StartsWith("Range"))
                    {

                        ARuleDetail = RuleDetails.Where(aItem => aItem.Rule.StartsWith("Equal")).FirstOrDefault();

                        var RangeNumbersStr = aRule.Substring(6).Replace(")", "");
                        var RangeNumbersArr = RangeNumbersStr.Split(',');

                        var RangeNumberFrom = int.Parse(RangeNumbersArr[0]);
                        var RangeNumberTo = int.Parse(RangeNumbersArr[1]);

                        Messages.AddRange(Range(aFieldInfo, RangeNumberFrom, RangeNumberTo, ARuleDetail));

                    }

                };

            });

            return Messages;
        }

        public void AddField(string fieldName, double? fieldValue , string validationRules)
        {


            FieldInfoList.Add(
                new FieldInfoDouble()
                {
                    FieldName = fieldName,
                    FieldValue = fieldValue,
                    ValidationRules = validationRules.Split(';')
                }
            );
        }

        private static List<IValidationMessage> Required(FieldInfoDouble aFieldInfo, IRuleDetail aRuleDetail)
        {

            var Messages = new List<IValidationMessage>();

            if (aFieldInfo.FieldValue == null)
            {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message.Replace("{FieldName}", aFieldInfo.FieldName),
                    FieldName = aFieldInfo.FieldName
                });
            };

            return Messages;

        }
        private static List<IValidationMessage> GreaterThan(FieldInfoDouble aFieldInfo, int greaterThanValue, IRuleDetail aRuleDetail) {

            var Messages = new List<IValidationMessage>();

            if (aFieldInfo.FieldValue == null ||aFieldInfo.FieldValue <= greaterThanValue) {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message.Replace("{FieldName}", aFieldInfo.FieldName)
                    .Replace("{FieldCriteria}", greaterThanValue.ToString())
                    ,
                    FieldName = aFieldInfo.FieldName
                });

            }

            return Messages;
        }
        private static List<IValidationMessage> LessThan(FieldInfoDouble aFieldInfo, int lessThanValue, IRuleDetail aRuleDetail)
        {

            var Messages = new List<IValidationMessage>();

            if (aFieldInfo.FieldValue == null || aFieldInfo.FieldValue >= lessThanValue)
            {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message.Replace("{FieldName}", aFieldInfo.FieldName)
                    .Replace("{FieldCriteria}", lessThanValue.ToString())
                    ,
                    FieldName = aFieldInfo.FieldName
                });
            }

            return Messages;
        }
        private static List<IValidationMessage> Equal(FieldInfoDouble aFieldInfo, int equalValue, IRuleDetail aRuleDetail)
        {

            var Messages = new List<IValidationMessage>();

            if (aFieldInfo.FieldValue == null || aFieldInfo.FieldValue != equalValue)
            {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message.Replace("{FieldName}", aFieldInfo.FieldName)
                    .Replace("{FieldCriteria}", equalValue.ToString())
                    ,
                    FieldName = aFieldInfo.FieldName
                });
            }

            return Messages;
        }
        private static List<IValidationMessage> Range(FieldInfoDouble aFieldInfo, int rangeFrom, int rangeTo, IRuleDetail aRuleDetail)
        {

            var Messages = new List<IValidationMessage>();



            if (aFieldInfo.FieldValue == null || 
                (aFieldInfo.FieldValue >= rangeFrom && aFieldInfo.FieldValue <= rangeTo) == false 
            ){

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message.Replace("{FieldName}", aFieldInfo.FieldName)
                    .Replace("{RangeFrom}", rangeFrom.ToString())
                    .Replace("{RangeTo}", rangeTo.ToString())
                    ,
                    FieldName = aFieldInfo.FieldName
                });
            }

            return Messages;
        }
    }
}
