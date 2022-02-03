using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public enum TaskStatus
    {
        ToDo,
        Doing,
        Done
    }
    public class StaffTask
    {
        public int StaffTaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateSet { get; set; }
        public DateTime DateDue { get; set; }
        public TaskStatus Status { get; set; }

        // Foreign keys
        public DevaStaffMember DevaStaffMember { get; set; }
        public int? DevaStaffMemberID { get; set; }

        public Family Family { get; set; }
        public int? FamilyID { get; set; }

        public Groups Group { get; set; }
        public int? GroupID { get; set; }
    }
}
