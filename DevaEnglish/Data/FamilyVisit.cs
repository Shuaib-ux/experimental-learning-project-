using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public class FamilyVisit
    {
        public int FamilyVisitID { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        
        // Foreign Keys
        public DevaStaffMember DevaStaffMember { get; set; }
        public int DevaStaffMemberID { get; set; }
        public Family Family { get; set; }
        public int FamilyID { get; set; }
    }
}