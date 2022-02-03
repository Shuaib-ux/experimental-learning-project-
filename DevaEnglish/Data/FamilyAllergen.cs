using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public class FamilyAllergen
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FamilyAllergenID { get; set; }

        public string AllergenType { get; set; }

        [ForeignKey("FamilyID")]
        public int FamilyID { get; set; }
    }
}
