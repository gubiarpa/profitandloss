using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apm.ProfitAndLoss.Datatier.Domain
{
    public class CuentaContable
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string Account { get; set; }
        public string TypeConcept { get; set; }
        public string Concept { get; set; }
        public string Subconcept { get; set; }
        public string Description { get; set; }
    }
}
