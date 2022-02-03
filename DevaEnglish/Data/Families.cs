using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DevaEnglish.Data
{
/*
    public enum Car
    {
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
    public enum FamilyStatus
    {
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
*/
    public class Families
    {
        [Key]
        public int FamilyID { get; set; }
        public int CanHost { get; set; }

        [StringLength(500)]
        public string Address { get; set; }
        public Double? AverageGrade { get; set; }
        public int Car { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        public int Frequency { get; set; }

        [StringLength(100)]
        public string PostCode { get; set; }

        public int SexPreference { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public int FamilyStatus { get; set; }

        public int NoOfFeedbacks { get; set; }

        public int FamilyType { get; set; }

        [StringLength(500)]
        public string FamilyName { get; set; }

        public Boolean? DietAllergen { get; set; }//can return null 
        [StringLength(255)]
        public string? DietAllergenList { get; set; }//can return null 

        public Boolean? Pet { get; set; } //can return null
        public byte[]? ImageData { get; set; }//can return null
        [StringLength(250)]
        public string? ImageDescription { get; set; }//can return null 
   
        public string? Email { get; set; } //can return null 

    }
}
