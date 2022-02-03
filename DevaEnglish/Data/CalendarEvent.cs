using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public class CalendarEvent
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string GroupID { get; set; }
        //May need to change date to string based on what the format is in the database.
        //Date may work when entering into calander though, needs testing
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public int FamilyID { get; set; }
    }
}
