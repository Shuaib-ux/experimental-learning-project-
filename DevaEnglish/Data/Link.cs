using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public class Link
    {

        public enum LinkStatus
        {
            Confirmed,
            Waiting,
            CantHost,
            Cancelled,
            Moved,
            Idea
        }
        public int LinkID { get; set; }
        public LinkStatus Status { get; set; }
        public string Notes { get; set; }
        public int NoOfMales { get; set; }
        public int NoOfFemales { get; set; }
        public int NoOfMaleStaff { get; set; }
        public int NoOfFemaleStaff { get; set; }
        public int NoOfTourGuides { get; set; }
        public int NoOfDrivers { get; set; }

        //Foreign Keys
        public Plans Plan { get; set; }
        public int PlanID { get; set; }
        public Family Family { get; set; }
        public int FamilyID { get; set; }

        public List<LinkChange> LinkChanges { get; set; }

    }
}
