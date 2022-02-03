using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public class FamilyMembers
    {
        [Key]
        public int FamilyMemberID { get; set; }

        [StringLength(50)]
        public string Forename { get; set; }

        [StringLength(50)]
        public string Surname { set; get; } // Suggested as family name, but customizable
        public DateTime DateOfBirth { get; set; }

        [StringLength(100)]
        public string Hobby { get; set; }
        public bool Lead { get; set; }

        [StringLength(50)]
        public string Occupation { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Notes { get; set; }


        public Families Details { get; set; }

        [ForeignKey("FamilyID")]
        public int FamilyID { get; set; }


    }
}
