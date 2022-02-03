using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public class FamilySafety
    {
        [ForeignKey("Family")]
        public int FamilySafetyID { get; set; }
        public bool GasSafetyStatus { get; set; }
        public string GasProof { get; set; }
        public string GasDetails { get; set; }
        public DateTime GasIssueDate { get; set; }
        public bool ElecSafetyStatus { get; set; }
        public string ElecProof { get; set; }
        public string ElecDetails { get; set; }
        public DateTime ElecIssueDate { get; set; }


        // Table Relationships
        public Family Family { get; set; }
    }
}
