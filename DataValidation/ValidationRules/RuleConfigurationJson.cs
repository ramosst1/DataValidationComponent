using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DataValidation.ValidationRules
{
    public class RuleConfigurationJson: IRuleConfiguration
    {

        private static List<IRuleDetail> RulesDetails = new List<IRuleDetail>();

        public List<IRuleDetail> GetRules()
        {

            if (!RulesDetails.Any()) {

                lock (this) {

                    var DirectoryPath = Directory.GetCurrentDirectory();


                    using (StreamReader r = new StreamReader($"{DirectoryPath}\\Configuration\\ValidationMessages.json"))
                    {
                        string json = r.ReadToEnd();

                        var Rules = JsonConvert.DeserializeObject<List<RuleDetailJson>>(json);

                        RulesDetails = Rules.Cast<IRuleDetail>().ToList();

                    }

                };
            }

            return RulesDetails;
        }

    }
}
