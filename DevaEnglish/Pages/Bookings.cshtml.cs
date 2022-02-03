using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevaEnglish.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DevaEnglish.Pages
{
    [Authorize]
    public class BookingsModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        [BindProperty]
        public IList<LinkGroup> LinkGroups { get; set; }
        public IList<Groups> Groups { get; set; }
        [BindProperty]
        public IList<MeetingPoints> MeetingPoint { get; set; }
        public IList<LinkPlan> LinkPlans { get; set; }
        public IList<Link> Links { get; set; }
        public IList<Plans> Plans { get; set; }
        public BookingsModel(Data.AppDbContext db, UserManager<ApplicationUser> UM)
        {
            _db = db;
            _userManager = UM;
        }
        public async Task OnGetAsync(int bookingResponse)
        {
            var user = await _userManager.GetUserAsync(User);
            var Family = await _db.Families.SingleOrDefaultAsync(f => f.Email == user.Email);
            PopulateProperties(Family);
            //Plans = _db.Plans.Where(x => x.PlanLetter == 'A').ToList();
            //Groupings = _db.Groups.Where(x => Plans.Any(y => y.GroupID == x.GroupID)).OrderBy(x => x.ArrivalDate).ToList();
            TempData["bookingResponse"] = bookingResponse;
        }

        private void PopulateProperties(Families Family)
        {
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
            LinkGroups = new List<LinkGroup>();
            foreach (var plan in LinkPlans)
            {
                foreach (var group in Groups)
                {
                    if (plan.PlanLetter == 'A' && plan.GroupID == group.GroupID)
                    {
                        LinkGroups.Add(new LinkGroup() { ArrivalDate = group.ArrivalDate, DepartureDate = group.DepartureDate, MeetingPointID = group.MeetingPointID, LinkID = plan.LinkID, Notes = plan.Notes, Status = plan.Status });
                    }
                }
            }
        }

        //Plans = _db.Plans.Where(x => x.PlanLetter == 'A' && Links.Any(y => y.PlanID == x.PlanID)).ToList();
        /*
             SELECT * FROM Families f
                INNER JOIN Links l ON L.FamilyID = f.FamilyID
                INNER JOIN Plans p ON p.PlanID = l.PlanID
                INNER JOIN Groups g ON g.GroupID = p.GroupID
                 WHERE f.FamilyID = 327 AND p.PlanLetter = 'A'
             */

        public async Task<IActionResult> OnPostAsync() {
            var user = await _userManager.GetUserAsync(User);
            var Family = await _db.Families.SingleOrDefaultAsync(f => f.Email == user.Email);
            try 
            {

                Links = _db.Links.Where(x => x.FamilyID == Family.FamilyID).ToList().Where(x => LinkGroups.Any(y => y.LinkID == x.LinkID)).ToList();
                foreach (var link in Links)
                {
                    var LinkGroup = LinkGroups.SingleOrDefault(x => x.LinkID == link.LinkID);
                    link.Status = LinkGroup.Status;
                    link.Notes = LinkGroup.Notes;
                    _db.Links.Update(link);
                }
                await _db.SaveChangesAsync();
                return RedirectToPage("/Homepage", new { bookingResponse = 1 }) ;
                //Plans = _db.Plans.Where(x => x.PlanLetter == 'A').ToList();
                //Groupings = _db.Groups.Where(x => Plans.Any(y => y.GroupID == x.GroupID)).OrderBy(x => x.ArrivalDate).ToList();
                //await _db.SaveChangesAsync();

            }
            catch (Exception e)
            {
                //throw new Exception($"Error SQL!", e);
                TempData["bookingResponse"] = 3;
            }
            PopulateProperties(Family);
            return Page();

        }
    }
}
