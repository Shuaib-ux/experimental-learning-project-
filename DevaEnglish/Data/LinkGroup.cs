using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DevaEnglish.Data.Link;

namespace DevaEnglish.Data
{
    public class LinkGroup
    {
        public int LinkID { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public int? MeetingPointID { get; set; }
        public LinkStatus Status { get; set; }
        public string Notes { get; set; }
    }
}
