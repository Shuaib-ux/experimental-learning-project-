using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DevaEnglish.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DevaEnglish.Pages.Family
{
    public class ViewDetailsModel : PageModel
    { 
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly AppDbContext _db; 
       
        public Families details { get; private set; }
        public IList<FamilyRooms> Rooms { get; private set; }
        public IList<FamilyPet> Pets { get; private set; }
       
        public ViewDetailsModel(AppDbContext db, UserManager<ApplicationUser> um)
        {
            _db = db;
            _usermanager = um;


         }
        public async Task OnGetAsync(int familyID)
        {
            
            
            if (familyID == 0 || familyID !=null)
            {
                var user = await _usermanager.GetUserAsync(User);
                  familyID = (await _db.Families.SingleOrDefaultAsync(f => f.Email == user.Email)).FamilyID;
                

            }
            Rooms = _db.FamilyRooms.Where(x => x.FamilyID == familyID).ToList();
            Pets = _db.FamilyPets.Where(x => x.FamilyID == familyID).ToList();
            details = _db.Families.SingleOrDefault(x => x.FamilyID == familyID);
            

        }

    }
}
