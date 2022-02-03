using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public class FamilyPet
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int FamilyPetID { get; set; }
        public string Type { get; set; }
        public bool HypoAllergenic { get; set; }
        // decide which pets are allergenic

        // Table Relationships
     
        [ForeignKey("FamilyID")]
        public int FamilyID { get; set; }
    }
}
