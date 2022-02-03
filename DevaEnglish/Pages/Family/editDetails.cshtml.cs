using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using DevaEnglish.Data;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace DevaEnglish.Pages.Family
{
    public class editDetailsModel : PageModel
    {
        //comment this out if this doesnt work
        private readonly UserManager<ApplicationUser> _usermanager;

        [BindProperty]
        public Families details { get; set; }
        [BindProperty]
        public FamilyPet Pets { get; set; }
        [BindProperty]
        public FamilyAllergen Allergens { get; set; }
        [BindProperty]
        public FamilyRooms Rooms { get; set; }
        private readonly AppDbContext _db;
        public editDetailsModel(AppDbContext db) { _db = db;}
        public async Task<IActionResult> OnGetAsync(int id)
        {
            details = await _db.Families.FindAsync(id);
            Pets = await _db.FamilyPets.FindAsync(id);
            Allergens = await _db.FamilyAllergen.FindAsync(id);
            Rooms = await _db.FamilyRooms.FindAsync(id);
            if(details == null)
            {
                return RedirectToPage("/Family/viewDetails");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostSave()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //comment this out if this doesnt work
            var user = await _usermanager.GetUserAsync(User);
            var updateDBrecord = await _db.Families.SingleOrDefaultAsync(f => f.Email == user.Email);
            var updateDBrecordRooms = _db.FamilyRooms.FirstOrDefault(f => f.FamilyID == updateDBrecord.FamilyID);
            var updateDBrecordPets = _db.FamilyPets.Where(f => f.FamilyID == updateDBrecord.FamilyID).ToList();
            var updateDBrecordAllergens = _db.FamilyAllergen.FirstOrDefault(f => f.FamilyID == updateDBrecord.FamilyID);
            updateDBrecord.FamilyName = details.FamilyName;
            updateDBrecord.CanHost = details.CanHost;
            updateDBrecord.FamilyName = details.FamilyName;
            updateDBrecord.SexPreference = details.SexPreference;
            updateDBrecord.FamilyStatus = details.FamilyStatus;
            updateDBrecord.Address = details.Address;
            updateDBrecord.City = details.City;
            updateDBrecord.PostCode = details.PostCode;
            updateDBrecord.Car = details.Car;
            updateDBrecord.DietAllergen = details.DietAllergen;
            updateDBrecord.Pet = details.Pet;
            updateDBrecord.ImageDescription = details.ImageDescription;
            updateDBrecordRooms.RoomNumber = Rooms.RoomNumber;
            updateDBrecordRooms.FamilyID = details.FamilyID;
            updateDBrecordAllergens.AllergenType = Allergens.AllergenType;
            updateDBrecordAllergens.FamilyID = details.FamilyID;

            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                details.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }

            _db.Attach(details).State = EntityState.Modified;
            try
            {
                _db.Families.Update(updateDBrecord);
                _db.FamilyAllergen.Update(updateDBrecordAllergens);
                _db.FamilyRooms.Update(updateDBrecordRooms);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception($"Family {details.FamilyID} could not be updated!", e);
            }
            return RedirectToPage("/Family/viewDetails");
        }
    }
}
