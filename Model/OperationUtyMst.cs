using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotonServices.Model
{
    public class OperationUtyMst
    {
        public int OperationsUtyID { get; set; }
        public string code { get; set; }
        public string OpCode { get; set; }

        public string Description { get; set; }

        public bool IsReminderdate { get; set; }

        public bool IsTTSStatus { get; set; }
    }
}
