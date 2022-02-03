using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DevaEnglish.Data.Link;

namespace DevaEnglish.Data
{
    public class LinkPlan
    {
        public int LinkID { get; set; }
        public int? GroupID { get; set; }
        public char PlanLetter { get; set; }
        public LinkStatus Status { get; set; }
        public string Notes { get; set; }
    }
}
