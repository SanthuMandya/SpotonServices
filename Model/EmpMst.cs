using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotonServices.Model
{
    public class EmpMst
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string ActiveFlag { get; set; }
        public string ManagerEmpCode { get; set; }
        public string Dept { get; set; }
        public string Email { get; set; }
    }
}
