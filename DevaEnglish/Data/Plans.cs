using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public class Plans
    {
        [Key]
        public int PlanID { get; set; }
       
        public char PlanLetter{ get; set; }
        //[ForeignKey("GroupID")]
        public int? GroupID { get; set; }
    }
}
