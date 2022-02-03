using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevaEnglish.Data
{

    public class LinkChange
    {
        public int LinkChangeID { get; set; }
        public string Description { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }

        // Staff Link
        public DevaStaffMember DevaStaffMember { get; set; }
        public int DevaStaffMemberID { get; set; }

        // Change to link to whichever record it's tracking
        public Link Link { get; set; }
        public int LinkID { get; set; }
    }
}