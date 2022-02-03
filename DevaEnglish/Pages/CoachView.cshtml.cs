using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevaEnglish.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DevaEnglish.Pages
{
    public class CoachViewModel : PageModel
    {
     
        public List<Plans> PlansWithLetterA { get; set; }
        public IList<Groups> CoachList { get; set; }
        public IList<MeetingPoints> MeetingPoint { get; private set; }
        private readonly AppDbContext _db;
        public CoachViewModel(Data.AppDbContext db)
        {
            //variable holds our database
            _db = db;
            PlansWithLetterA = _db.Plans.Where(x => x.PlanLetter == 'A').ToList();
            CoachList = new List<Groups>();
        }
        public void OnGet() 
        {
            foreach (var plan in PlansWithLetterA)
            {

                CoachList.Add(
                    _db.Groups.Where(x => x.GroupID == plan.GroupID).FirstOrDefault()
                    );
            }


            MeetingPoint = _db.MeetingPoints.FromSqlRaw("SELECT * FROM MeetingPoints").ToList();
            //Plans = _db.Plans.Where(x => x.GroupID == groupID && x.PlanLetter == 'A').ToList();
        }
    }
}
