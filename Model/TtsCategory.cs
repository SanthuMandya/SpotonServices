using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotonServices.Model
{
    public class TtsCategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int MainCategoryID { get; set; }
        public bool? CloseCat { get; set; }
        public int ParentID { get; set; }
        public string Priority { get; set; }
        public bool IsActive { get; set; }
        public int CRMWarningSLA { get; set; }
    }
}
