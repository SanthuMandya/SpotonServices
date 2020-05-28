using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotonServices.Model
{
    public class ConMovementDetails
    {
        public string Name { get; set; }
        public int Total { get; set; }
        public int? Crossed { get; set; }
        public int? NotCrossed { get; set; }
        public int? Air { get; set; }
        public int? Surface { get; set; }
    }
}
