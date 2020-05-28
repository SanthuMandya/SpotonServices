using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotonServices.Model
{
    public class AccountCurrentMapping : AgentCurrentMapping
    {
        public string AccountCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerTerritory { get; set; }
    }
}
