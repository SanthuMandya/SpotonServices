using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotonServices.Model
{
    public class AccountInfo
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountForPickup { get; set; }
        public string ParentAccount { get; set; }
        public string CustBranchCode { get; set; }
        public string ProductType { get; set; }
    }
}
