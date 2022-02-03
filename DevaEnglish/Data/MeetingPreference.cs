using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevaEnglish.Data
{
    public class MeetingPreference
    {
        public int MeetingPreferenceID { get; set; }
        public int Rank { get; set; }

        //Foreign Key
        public Family Family { get; set; }
        public int FamilyID { get; set; }

        public MeetingPoints MeetingPoint { get; set; }
        public int MeetingPointID { get; set; }
    }
}
