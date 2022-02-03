using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DevaEnglish.Data;
using Microsoft.EntityFrameworkCore;

namespace DevaEnglish.Pages.Family
{
    public class FamilyBioModel : PageModel
    {
        private readonly AppDbContext _db;
        public IList<FamilyMembers> Members { get;  set; }
        public IList<Families> details { get;set; }

        [BindProperty]

        public string Search { get; set; }
        public FamilyBioModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(int familyID)
        {
            Members = _db.FamilyMembers.Where(x => x.FamilyID == familyID).ToList();
        }
        public IActionResult OnPostSearch()
        {
            Members = _db.FamilyMembers.FromSqlRaw("SELECT * FROM FamilyMembers WHERE FamilyName LIKE '" + Search + "%' ORDER BY Forename DESC").ToList();
            return Page();
        }
    }
}
