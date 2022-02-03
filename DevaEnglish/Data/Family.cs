using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public enum Car {
        [Display(Name = "None")]
        None,
        [Display(Name = "4 Seater")]
        FourSeater,
        [Display(Name = "5 Seater")]
        FiveSeater,
        [Display(Name = "People Carrier")]
        PeopleCarrier
    }
    public enum SexPreference
    {
        OnlyMale,
        OnlyFemale,
        MaleFemale, // Prefers male, will host female
        FemaleMale, // Prefers female, will host male
        Teacher, // Will host teachers & both sexes
        Both // Hosts either male or female students
    }    
    public enum FamilyStatus { 
        Active,
        Archived,
        Enquiry,
        New
    }
    public enum FamilyType
    {
        Both,
        Organiser,
        Family
    }
    public class Family
    {
        // Family Details
        public int FamilyID { get; set; }
        public string FamilyName { get; set; }
        public string DisplayName { get; set; } // TODO: Not yet implemented - get forenames of lead members and surname
        public string Email { get; set; }
        public FamilyStatus FamilyStatus { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public Car Car { get; set; }
        public double AverageGrade { get; set; } // Generated from feedback scores when new score added
        public int NoOfFeedbacks { get; set; } // To calculate future averages when added
        public string Notes { get; set; }
        public FamilyType FamilyType { get; set; }

        public int CanHost { get; set; }
        public int Frequency { get; set; }
        public SexPreference SexPreference { get; set; }


        // One to one
        public FamilySafety FamilySafety { get; set; }
        
        // Links to this table
        public List<FamilyMembers> FamilyMembers { get; set; }
        public List<FamilyPet> FamilyPets { get; set; }
        public List<FamilyCanTake> FamilyCanHost { get; set; }
        public List<FamilyIs> FamilyIs { get; set; }
        public List<Feedback> FeedbackScores { get; set; }
        public List<MeetingPreference> MeetingPreferences { get; set; }
        public List<FamilyVisit> FamilyVisits { get; set; }
        public List<FamilyRooms> FamilyRooms { get; set; }
        public List<FamilyAvailabilities> FamilyAvailabilities { get; set; }
        public List<Link> Links { get; set; }
        public List<FamilyComm> familyComms { get; set; }
        public List<StaffTask> StaffTasks { get; set; }
        public List<FamilyChange> FamilyChanges { get; set; }

    }
}
