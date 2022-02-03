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
    public class AvailabilitiesModel : PageModel
    {
       
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        [BindProperty]
        public IList<FamilyAvailabilities> FamilyAvailability { get; set; }
        public AvailabilitiesModel(Data.AppDbContext db, UserManager<ApplicationUser> UM)
        {
            _db = db;
            _userManager = UM;
        }
        public async Task OnGetAsync(int availabilityResponse)
        {
            var user = await _userManager.GetUserAsync(User);
            var Family = await _db.Families.SingleOrDefaultAsync(f => f.Email == user.Email);
            FamilyAvailability = _db.FamilyAvailabilities.Where(x => x.FamilyID == Family.FamilyID).OrderBy(x => x.StartDate).ToList();
            TempData["availabilityResponse"] = availabilityResponse;
        }
        /*public void OnGet()
        {
        
            //FamilyAvailability = _db.FamilyAvailabilities.Where(x => x.FamilyID = ).OrderBy(x => x.StartDate).ToList();
        } */
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                _db.FamilyAvailabilities.UpdateRange(FamilyAvailability);//adds entry to db
                await _db.SaveChangesAsync();
                return RedirectToPage("/Homepage", new { availabilityResponse = 1 });
            }
            catch (Exception e)
            {
                //throw new Exception($"Error SQL!", e);
                TempData["availabilityResponse"] = 3;
            }

            return Page();

        }
    }
}
