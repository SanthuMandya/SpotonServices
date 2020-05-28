namespace SpotonServices.Model
{
    public class SpotonAccountDetails
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string CsAgent { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public string Depot { get; set; }
        public string Branch { get; set; }

        //AccountInfo
        public string ParentAccount { get; set; }
        public string ProductType { get; set; }
        public string AccountForPickup { get; set; }
        public string CustBranchCode { get; set; }
    }
}
