using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevaEnglish.Data
{

    public class FamilyChange
    {
        public int FamilyChangeID { get; set; }
        public string ChangeType { get; set; }
        public string Description { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }

        // Staff Link
        public DevaStaffMember StaffMember { get; set; }
        public int DevaStaffMemberID { get; set; }

        // Change to link to whichever record it's tracking
        public Family Family { get; set; }
        public int FamilyID { get; set; }
    }
}