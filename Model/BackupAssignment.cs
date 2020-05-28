using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotonServices.Model
{
    public class BackupAssignment
    {
        public int EmpBackupAssignId { get; set; }
        public string SubordinateId { get; set; }
        public string AccountCode { get; set; }
        public string BackupAgentId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsEditable { get; set; }

        //Newly Added Properties
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
