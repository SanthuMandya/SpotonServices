using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotonServices.Model
{
    public class AccountDetails
    {
        //neh
        public string CategoryName { get; set; }
        public int? Category { get; set; }
        public double? CreditBillingTerm { get; set; }
        public double? FtcBillingTerm { get; set; }
        public string CashCode { get; set; }
        public string Territory { get; set; }
        public string TerritoryManager { get; set; }
        public string IndustryType { get; set; }
        public string CustomerType { get; set; }
        public string CsAgent { get; set; }
        public string CsTeamLeader { get; set; }
        public string CsManager { get; set; }
    }
}
