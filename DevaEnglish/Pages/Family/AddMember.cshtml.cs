using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevaEnglish.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevaEnglish.Pages.Family
{
    public class AddMemberModel : PageModel
    {
        private AppDbContext _db;
        [BindProperty]
        public FamilyMembers Members { get; set; }
        public AddMemberModel (AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { return Page(); }
            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);

                ms.Close();
                ms.Dispose();
            }
            _db.FamilyMembers.Add(Members);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Family/FamilyBio");
        }

    }
}
