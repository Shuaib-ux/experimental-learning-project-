using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public enum AvailabilityStatus
    {
        Available,
        Unavailable,
        Reserve,
        Keen,
        AssumedAvailable // Display Only, Not used for DB
    }
    public class FamilyAvailabilities
    {
        [Key] //Primary key
        public int FamilyAvailabilityID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AvailabilityStatus Status { get; set; }
        public string Notes { get; set; }
        //Foreign key
        public int FamilyID { get; set; }
    }
}
