using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public class FamilyCanTake
    {
        public int FamilyCanTakeID { get; set; }
        public string Type { get; set; }

        // Table Relationships
        public Family Family { get; set; }
        public int FamilyID { get; set; }
    }
}
