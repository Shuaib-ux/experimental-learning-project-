using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public class DevaStaffMember
    {
        public int DevaStaffMemberID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }

        public List<FamilyMemberDbs> FamilyMemberDbsList { get; set; } // DBS's done by this staff member
        public List<FamilyVisit> FamilyVisits { get; set; } // Visits done by this staff member
        public List<StaffTask> StaffTasks { get; set; } // Tasks for this user
        
        public List<LinkChange> LinkChanges { get; set; } // Tasks for this user
        public List<FamilyChange> FamilyChanges { get; set; } // Tasks for this user
    }
}
