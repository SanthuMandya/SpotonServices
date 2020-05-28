using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotonServices.Model
{
    public class PickupStatusDetails
    {
        public string AccountCode { get; set; }
        public string CSAgent { get; set; }
        public bool IsODA { get; set; }
        public string OrderNo { get; set; }
        public string PickupDate { get; set; }
        public string PickupRegion { get; set; }
        public decimal Weight { get; set; }
        public string RegSource { get; set; }
        public string PType { get; set; }
    }
}
