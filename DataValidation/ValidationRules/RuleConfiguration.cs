using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace DataValidation.ValidationRules
{
    public class RuleConfiguration : IRuleConfiguration
    {

        private static List <IRuleDetail> Rules = new List<IRuleDetail>();

        public List<IRuleDetail> GetRules() {


            if (!Rules.Any()) {

                lock (this) {

                    IRuleConfiguration ARuleConfig = new RuleConfigurationJson();

                    Rules = ARuleConfig.GetRules();
                }

            }
            return Rules;

        }



    }
}
