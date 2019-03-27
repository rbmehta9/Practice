using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentDirect.CoreService.Contract.Message.Configuration;
using  ContentDirect.ConfigurationManagement.Contract.Data;
using Newtonsoft.Json;


namespace JsonSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            var req = new RetrieveCodeTablesRequest();
            req.CodeTypes = new List<CodeType>()
            {
                CodeType.RecurringBillerRuleConfiguration
            };

            req.IncludeTranslations = false;
            var jsonstr = JsonConvert.SerializeObject(req);
        }
    }
}
