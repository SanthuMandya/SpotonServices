using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotonServices.Model
{
    public class CRMContactDetails
    {
        public int ContId { get; set; }
        public string ContPtmsptcd { get; set; }
        public string ContPtmsptnm { get; set; }
        public string ContFirstName { get; set; }
        public string ContMiddleName { get; set; }
        public string ContLastName { get; set; }
        public string ContJobTitle { get; set; }
        public string ContEmail { get; set; }
        public string ContDepartment { get; set; }
        public string ContLocation { get; set; }
        public string ContSource { get; set; }
        public string ContMobileNumber { get; set; }
        public string ContBusinessPhone { get; set; }
        public DateTime ContCreatedon { get; set; }
        public string ContCreatedby { get; set; }
        public DateTime? ContModifiedon { get; set; }
        public string ContModifiedby { get; set; }
        public bool ContStatus { get; set; }
        public string FullName { get; set; }
    }
}
