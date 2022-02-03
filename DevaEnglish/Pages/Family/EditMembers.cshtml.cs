using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DevaEnglish.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.IO;

namespace DevaEnglish.Pages.Family
{
    public class EditMembersModel : PageModel
    {
        [BindProperty]
        public FamilyMembers Members { get; set; }
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManger;
        public EditMembersModel(AppDbContext db, UserManager<ApplicationUser> um)
        {
            _db = db;
            _userManger = um;
        }
        
        
        public async Task<IActionResult> OnGetAsync(int id)
        {
            
            Members = await _db.FamilyMembers.FindAsync(id);
            if (Members == null)
            {
                return RedirectToPage("/Family/FamilyBio");
            }

            return Page();
        }
        public async Task<IActionResult> OnPostSave()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                ms.Close();
                ms.Dispose();
            }

            _db.Attach(Members).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception($"Family {Members.FamilyID} could not be updated!", e);
            }
            return RedirectToPage("/Family/FamilyBio");
        }
    }
}
