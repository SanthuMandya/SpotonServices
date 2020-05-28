using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotonServices.Model
{
    public class PickupDetails
    {
        public string Name { get; set; }
        public int? ODA { get; set; }
        public int? STD { get; set; }
        public int? CS { get; set; }
        public int? System { get; set; }
        public int? North { get; set; }
        public int? East { get; set; }
        public int? West { get; set; }
        public int? South { get; set; }
    }
}
