using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public class MeetingPoints
    {
        [Key]
        public int MeetingPointID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string CoachSpace { get; set; }
        public string Directions { get; set; }
        public string Notes { get; set; }


        // Links to this table
        public List<Groups> Groups { get; set; }
    }
}
