using System;

namespace SpotonServices.Model
{
    public class CaseAccountDetails
    {
        public string AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string OriginBranch { get; set; }
        public string DestinationBranch { get; set; }
        public string CurrentBranch { get; set; }
        public string Consignee { get; set; }
        public string Consigner { get; set; }
    }
}
