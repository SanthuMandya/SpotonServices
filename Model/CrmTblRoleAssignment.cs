using System;
using System.Collections.Generic;
using System.Text;

namespace SpotonServices.Model
{
    public class CrmTblRoleAssignment
    {
        public string EMPCD { get; set; }
        public string EmpSuperviserId { get; set; }
        public int GroupMasterId { get; set; }
        public bool isDeleted { get; set; }
    }

}
