using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DevaEnglish.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DevaEnglish.Pages
{
    public class CalendarModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        [BindProperty]
        public IList<CalendarEvent> AvailabilityEvents { get; set; }
        public IList<CalendarEvent> CoachEvents { get; set; }
        public IList<FamilyAvailabilities> FamilyAvailability { get; private set; }
        public IList<Groups> Groups { get; private set; }
        public IList<MeetingPoints> MeetingPoint { get; private set; }
        public IList<Link> Links { get; private set; }
        public IList<Plans> Plans { get; private set; }
        public IList<LinkPlan> LinkPlans { get; set; }
        public IList<LinkGroup> LinkGroups { get; set; }

        public CalendarModel(Data.AppDbContext db, UserManager<ApplicationUser> UM)
        {
            _db = db;
            _userManager = UM;
        }
        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var Family = await _db.Families.SingleOrDefaultAsync(f => f.Email == user.Email);
            FamilyAvailability = _db.FamilyAvailabilities.Where(x => x.FamilyID == Family.FamilyID).OrderBy(x => x.StartDate).ToList();
            AvailabilityEvents = new List<CalendarEvent>();
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            foreach (var availability in FamilyAvailability)
            {
                string weekNumber = ciCurr.Calendar.GetWeekOfYear(availability.StartDate, CalendarWeekRule.FirstDay, DayOfWeek.Monday).ToString();
                string twoDigitYear = availability.StartDate.ToString("yy");
                string title = "Week No: " + weekNumber + " Year: " + twoDigitYear;
                AvailabilityEvents.Add(new CalendarEvent() { ID = availability.FamilyAvailabilityID, Title = title, GroupID = "Availability", StartDate = availability.StartDate, EndDate = availability.EndDate });
            }
            MeetingPoint = _db.MeetingPoints.ToList();

            Links = _db.Links.Where(x => x.FamilyID == Family.FamilyID).ToList();
            LinkPlans = new List<LinkPlan>();
            Plans = _db.Plans.ToList();
            foreach (var plan in Plans)
            {
                foreach (var link in Links)
                {
                    if (plan.PlanID == link.PlanID)
                    {
                        LinkPlans.Add(new LinkPlan() { PlanLetter = plan.PlanLetter, GroupID = plan.GroupID, LinkID = link.LinkID, Notes = link.Notes, Status = link.Status });
                    }
                }
            }
            Groups = _db.Groups.OrderBy(x => x.ArrivalDate).ToList();
            CoachEvents = new List<CalendarEvent>();
            foreach (var plan in LinkPlans)
            {
                foreach (var group in Groups)
                {
                    if (plan.PlanLetter == 'A' && plan.GroupID == group.GroupID)
                    {
                        string pointName = "";
                        foreach (var point in MeetingPoint)
                        {
                            if (group.MeetingPointID == point.MeetingPointID)
                            {
                                pointName = point.Name;
                            }
                        }
                        CoachEvents.Add(new CalendarEvent() { ID = plan.LinkID, Title = pointName, GroupID = "Coach", StartDate = group.ArrivalDate, EndDate = group.DepartureDate });
                    }
                }
            }
            /*Groups = _db.Groups.FromSqlRaw("SELECT * FROM Groups").ToList();
            MeetingPoint = _db.MeetingPoints.FromSqlRaw("SELECT * FROM MeetingPoints").ToList(); */
        }
    }
}
