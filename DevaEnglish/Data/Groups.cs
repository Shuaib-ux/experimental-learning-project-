using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public enum GroupStatus
    {
        Enquiry,
        Confirmed,
        Cancelled,
        WaitingList,
        Refused
    }
    public class Groups
    {
        [Key]
        public int GroupID { get; set; }
        public string Name { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string WeekNumbers { get; set; }
        public string? Code { get; set; }
        public int Type { get; set; }
        public GroupStatus Status { get; set; }
        public DateTime? OptionDeadline { get; set; }
        public string LeaderName { get; set; }
        public string Phone { get; set; }
        public string PlacementReqs { get; set; }

        public int? NoOfMales { get; set; }
        public int? NoOfFemales { get; set; }
        public int? NoOfMaleStaff { get; set; }
        public int? NoOfFemaleStaff { get; set; }
        public int? NoOfDrivers { get; set; }
        public int? NoTourGuides { get; set; }

        public DateTime? AvailabilitySent { get; set; }
        public DateTime? AllocationReceived { get; set; }
        public DateTime? ItineraryReceived { get; set; }
        public DateTime? PaymentRecieved { get; set; }
        public DateTime? SentLocalOrgInfo { get; set; }
        public string AgeRange { get; set; }
        public string Nationality { get; set; }
        public string Notes { get; set; }
        public string OrganiserNotes { get; set; }

        // Foreign Keys
        [ForeignKey("AgencyID")]
        public int? AgencyID { get; set; }
        [ForeignKey("FamilyID")]
        public int? FamilyID { get; set; }
        //public Agency Agency { get; set; }
        [ForeignKey("AgencyStaffID")]
        public int? AgencyStaffID { get; set; }
        //public AgencyStaff AgencyStaff { get; set; }
        [ForeignKey("MeetingPointID")]
        public int? MeetingPointID { get; set; }
        public MeetingPoints MeetingPoint { get; set; }
        //public int? LocalOrganiserID { get; set; }
        //public LocalOrganiser LocalOrganiser { get; set; }
    }
}
