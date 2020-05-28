using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotonServices.Model
{
    public class UserList
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmailId { get; set; }
        public string SupervisorName { get; set; }
        public string SupervisorId { get; set; }
        public string SubGroup { get; set; }
        public string Department { get; set; }
    }
}
