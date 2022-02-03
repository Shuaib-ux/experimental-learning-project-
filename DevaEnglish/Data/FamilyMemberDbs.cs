using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public enum DbsStatus
    {
        None,
        Applied,
        OnApplication,
        E,
        WA,
        SA,
        S,
        Excluded,
        
    }
    public class FamilyMemberDbs
    {
        [ForeignKey("FamilyMember")]
        public int FamilyMemberDbsID { get; set; }
        public string CertificateNo { get; set; }
        public DateTime IssueDate { get; set; }
        public string DbsBy { get; set; }
        public DbsStatus Status { get; set; }
        public int? DevaStaffMemberID { get; set; } // Seen by staff member
        public DateTime DateSeen { get; set; }
        public bool OwnHome { get; set; }
        public bool Enhanced { get; set; }
        public bool ChildWorkforce { get; set; }
        public bool OnlineUpdate { get; set; }
        public DateTime PermissionRecieved { get; set; }
        public string OnlineUpdateInfo { get; set; }
        public DateTime MostRecentOnline { get; set; }


        public FamilyMembers FamilyMember { get; set; }
        public DevaStaffMember DevaStaffMember { get; set; }

    }
}
