using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotonServices.Model
{
    public class SpotonStaticCaseDetails
    {
        public string CaseRefNumber { get; set; }
        public string CaseEspotonNumber { get; set; }
        public string CrmCaseNumber { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string CaseType { get; set; }
        public string CaseAccountNumber { get; set; }
        public string CaseAccountName { get; set; }
        public string Consignee { get; set; }
        public string Consigner { get; set; }
        public string OriginBranch { get; set; }
        public string DestinationBranch { get; set; }
        public string CurrentBranch { get; set; }
        public string PickupDate { get; set; }
        public string DueDate { get; set; }
        public string CaseSource { get; set; }
        public string Priority { get; set; }
        public string ProductType { get; set; }
        public string DeliveryDate { get; set; }
        public int? MainCategoryId { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public string PkgsChargeWt { get; set; }

    }
}
