using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using DataValidation.ValidationRules;

namespace DataValidation.ValidationProcess
{
    class ValidatorSingleString: IValidatorSingleFieldString
    {

        private IRuleConfiguration RulesConfig; 

        private List <IRuleDetail> RuleDetails;
        public ValidatorSingleString(IRuleConfiguration ruleConfig)
        {
            RulesConfig = ruleConfig;

            RuleDetails = RulesConfig.GetRules();

        }
        List <FieldInfoString> FieldInfoList = new List<FieldInfoString>();

        public void AddField(string fieldName, string fieldValue, string validationRules)
        {
            FieldInfoList.Add(
                new FieldInfoString() {
                    FieldName = fieldName,
                    FieldValue = fieldValue,
                    ValidationRules = validationRules.Split(';')
                }
            );
        }

        public List <IValidationMessage> Validate() {

            var Messages = new List<IValidationMessage>();

            FieldInfoList.ForEach(delegate (FieldInfoString aFieldInfo)
            {
                foreach (var aRule in aFieldInfo.ValidationRules) {

                    IRuleDetail ARuleDetail;

                    ARuleDetail = RuleDetails.FirstOrDefault(
                        aItem => aItem.Rule.Equals(aRule.Trim(), StringComparison.CurrentCultureIgnoreCase)
                    );

                    switch (aRule.Trim())
                    {
                        case "Required":

                            Messages.AddRange(IsRequired(aFieldInfo, ARuleDetail));

                            break;
                        case "IsEmail":

                            Messages.AddRange(IsEMailAddress(aFieldInfo, ARuleDetail));
                            break;
                        case "IsUserName":

                            Messages.AddRange(IsUserName(aFieldInfo, ARuleDetail));
                            break;
                        case "Password":

                            Messages.AddRange(IsPassword(aFieldInfo, ARuleDetail));
                            break;

                        case "AlphaCharOnly":
                            Messages.AddRange(IsAlphaCharOnly(aFieldInfo, ARuleDetail));
                            break;

                        case "AlphaNumericOnly":
                            
                            Messages.AddRange(IsAlphaNumericOnly(aFieldInfo, ARuleDetail));
                            break;

                        case "NumbersOnly":
                            Messages.AddRange(IsNumbersOnly(aFieldInfo, ARuleDetail));
                            break;

                        case "IsCurrency":
                            Messages.AddRange(IsCurrency(aFieldInfo, ARuleDetail));
                            break;
                    }

                    if (aRule.StartsWith("LengthMin"))
                    {

                        ARuleDetail = RuleDetails.Where(aItem => aItem.Rule.StartsWith("LengthMin")).FirstOrDefault();

                        var LengthMinStr = aRule.Substring(10).Replace(")", "");

                        var LengthMin = int.Parse(LengthMinStr);

                        Messages.AddRange(IsLengthMinium(aFieldInfo, LengthMin, ARuleDetail));

                    }

                    if (aRule.StartsWith("LengthMax"))
                    {

                        ARuleDetail = RuleDetails.Where(aItem => aItem.Rule.StartsWith("LengthMax")).FirstOrDefault();

                        var LengthMinStr = aRule.Substring(10).Replace(")", "");

                        var LengthMax = int.Parse(LengthMinStr);

                        Messages.AddRange(IsLengthMaximum(aFieldInfo, LengthMax, ARuleDetail));

                    }

                    if (aRule.StartsWith("IsDate")) {

                        ARuleDetail = RuleDetails.Where(aItem => aItem.Rule.StartsWith("IsDate")).FirstOrDefault();

                        var DateFormat = aRule.Substring(7).Replace(")", "");

                        Messages.AddRange(IsDate(aFieldInfo, DateFormat, ARuleDetail));

                    }


                };


            });

            return Messages;
        }

        private static List<IValidationMessage> IsRequired(FieldInfoString aFieldInfo, IRuleDetail aRuleDetail) {

            var Messages = new List<IValidationMessage>();

            if (String.IsNullOrWhiteSpace(aFieldInfo.FieldValue)) {

                Messages.Add(new ValidationMessage()
                { 
                    ErrorMessage = aRuleDetail.Message.Replace("{FieldName}",aFieldInfo.FieldName),
                    FieldName = aFieldInfo.FieldName
                });
            };

            return Messages;

        }

        private static List<IValidationMessage> IsEMailAddress(FieldInfoString aFieldInfo, IRuleDetail aRuleDetail) {

            var Messages = new List<IValidationMessage>();


            if (!Regex.IsMatch(aFieldInfo.FieldValue, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"))
            {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message.Replace("{FieldName}", aFieldInfo.FieldName),
                    FieldName = aFieldInfo.FieldName
                });
            }

            return Messages;

        }

        private static List<IValidationMessage> IsUserName(FieldInfoString aFieldInfo, IRuleDetail aRuleDetail)
        {

            var Messages = new List<IValidationMessage>();

            var ValidUsername = true;

            if (string.IsNullOrWhiteSpace(aFieldInfo.FieldValue)) {

                ValidUsername = false;

                goto FinalResults;
            }

            if (aFieldInfo.FieldValue.Trim().Length < 9 || aFieldInfo.FieldValue.Trim().Length > 15) {

                ValidUsername = false;

                goto FinalResults;
            }

            if (!Regex.IsMatch(aFieldInfo.FieldValue, @"^*[a-z]"))
            {
                ValidUsername = false;

                goto FinalResults;
            }

            if (!Regex.IsMatch(aFieldInfo.FieldValue, @"^*[A-Z]"))
            {
                ValidUsername = false;

                goto FinalResults;
            }

            if (!Regex.IsMatch(aFieldInfo.FieldValue, @"^*[0-9]"))
            {
                ValidUsername = false;

                goto FinalResults;
            }

            FinalResults:

            if (ValidUsername == false) {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message.Replace("{FieldName}", aFieldInfo.FieldName),
                    FieldName = aFieldInfo.FieldName
                });

            }

            return Messages;
        }

        private static List<IValidationMessage> IsPassword(FieldInfoString aFieldInfo, IRuleDetail aRuleDetail) {

            var Messages = new List<IValidationMessage>();

            if (string.IsNullOrWhiteSpace(aFieldInfo.FieldValue)){

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message.Replace("{FieldName}", aFieldInfo.FieldName),
                    FieldName = aFieldInfo.FieldName
                });

                goto FinalResults;
            }

            if (aFieldInfo.FieldValue.Trim().Length < 8) {
                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message.Replace("{FieldName}", aFieldInfo.FieldName),
                    FieldName = aFieldInfo.FieldName
                });

                goto FinalResults;

            }

            #region "Only alpha and numeric "
            if (!Regex.IsMatch(aFieldInfo.FieldValue, @"^[a-zA-Z0-9\s,]*$"))
            {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message.Replace("{FieldName}", aFieldInfo.FieldName),
                    FieldName = aFieldInfo.FieldName
                });
            }
            #endregion

            FinalResults:  return Messages;

        }
        private static List<IValidationMessage> IsAlphaCharOnly(FieldInfoString aFieldInfo, IRuleDetail aRuleDetail) {
            var Messages = new List<IValidationMessage>();


            if (!Regex.IsMatch(aFieldInfo.FieldValue, @"^[a-zA-Z]+$")) {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message.Replace("{FieldName}", aFieldInfo.FieldName),
                    FieldName = aFieldInfo.FieldName
                });
            }

            return Messages;
        }

        private static List<IValidationMessage> IsAlphaNumericOnly(FieldInfoString aFieldInfo, IRuleDetail aRuleDetail)
        {
            var Messages = new List<IValidationMessage>();


            if (!Regex.IsMatch(aFieldInfo.FieldValue, @"^[a-zA-Z0-9]*$"))
            {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message.Replace("{FieldName}", aFieldInfo.FieldName),
                    FieldName = aFieldInfo.FieldName
                });
            }

            return Messages;
        }

        private static List<IValidationMessage> IsNumbersOnly(FieldInfoString aFieldInfo, IRuleDetail aRuleDetail) {

            var Messages = new List<IValidationMessage>();


            if (!Regex.IsMatch(aFieldInfo.FieldValue, @"^[0-9]*$"))
            {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message.Replace("{FieldName}", aFieldInfo.FieldName),
                    FieldName = aFieldInfo.FieldName
                });
            }

            return Messages;

        }

        private static List<IValidationMessage> IsLengthMinium(FieldInfoString aFieldInfo, int lengthMin, IRuleDetail aRuleDetail) {

            var Messages = new List<IValidationMessage>();

            if (aFieldInfo.FieldValue?.Trim().Length < lengthMin) {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message
                        .Replace("{FieldName}", aFieldInfo.FieldName)
                        .Replace("{FieldLength}", lengthMin.ToString())
                    ,FieldName = aFieldInfo.FieldName
                });

            }

            return Messages;

        }

        private static List<IValidationMessage> IsLengthMaximum(FieldInfoString aFieldInfo, int lengthMax, IRuleDetail aRuleDetail)
        {
            var Messages = new List<IValidationMessage>();

            if (aFieldInfo.FieldValue?.Trim().Length > lengthMax)
            {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message
                        .Replace("{FieldName}", aFieldInfo.FieldName)
                        .Replace("{FieldLength}", lengthMax.ToString())
                    ,FieldName = aFieldInfo.FieldName
                });

            }

            return Messages;

        }
        private static List<IValidationMessage> IsCurrency(FieldInfoString aFieldInfo, IRuleDetail aRuleDetail) {

            var Messages = new List<IValidationMessage>();

            var ValidCurrency = true;

            var IsDigit = Regex.IsMatch(aFieldInfo.FieldValue, @"^-?\d+$");
            var IsDigitWithDecimal = Regex.IsMatch(aFieldInfo.FieldValue, @"^-?\d+\.\d{2}$");

            if (IsDigit == false && IsDigitWithDecimal == false)
            {
                ValidCurrency = false;

                goto FinalResults;
            }


            FinalResults:

            if (ValidCurrency == false) {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message.Replace("{FieldName}", aFieldInfo.FieldName),
                    FieldName = aFieldInfo.FieldName
                });

            }
            return Messages;
        }

        private static List<IValidationMessage> IsDate(FieldInfoString aFieldInfo, string format, IRuleDetail aRuleDetail) {
            var Messages = new List<IValidationMessage>();

            var enUS = new CultureInfo("en-US");

            DateTime TempDateTime;

            if (!DateTime.TryParseExact(aFieldInfo.FieldValue, format, enUS, DateTimeStyles.None, out TempDateTime)) {

                Messages.Add(new ValidationMessage()
                {
                    ErrorMessage = aRuleDetail.Message.Replace("{FieldName}", aFieldInfo.FieldName),
                    FieldName = aFieldInfo.FieldName
                });

            };

            return Messages;
        }

    }
}
