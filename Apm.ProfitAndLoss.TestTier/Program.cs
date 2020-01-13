using Apm.ProfitAndLoss.Datatier.Base;
using Apm.ProfitAndLoss.Datatier.Contract.Repository;
using Apm.ProfitAndLoss.Datatier.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apm.ProfitAndLoss.TestTier
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonConfig.LoadFile("D:\\Applications\\apm.profitloss\\Apm.ProfitAndLoss.TestTier\\Templates\\Credentials.json");
            JsonConfig.SetSetting("cred.user", "billy");
            Console.WriteLine(JsonConfig.GetSetting("cred.user"));
            Console.ReadKey();
        }
    }
}

