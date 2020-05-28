using System;

namespace SpotonServices.Model
{
    public class ConMovements
    {
        public string DockNo { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string CurrentLocation { get; set; }
        public string BookingDate { get; set; }
        public string DueDate { get; set; }
        public string AccountCode { get; set; }
        public string CSAgent { get; set; }
        public string Wt_Pcs { get; set; }
        public string LatestStatusCode { get; set; }
        public string ProductType { get; set; }
        public string DocStatus { get; set; }

        public string userHeirarchy { get; set; }
        public string dateDue { get; set; }
        public string dcStatus { get; set; }
        public string pType { get; set; }
    }
}
