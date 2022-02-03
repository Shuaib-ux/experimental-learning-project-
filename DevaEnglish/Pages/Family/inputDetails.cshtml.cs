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
using System.ComponentModel.DataAnnotations.Schema;

namespace DevaEnglish.Pages.Family
{
    public class inputDetailsModel : PageModel
    {
        private AppDbContext _db;
        private readonly UserManager<ApplicationUser> _usermanager;

        [BindProperty]
        public Families details { get; set; }

        [BindProperty]
        public IList<FamilyPet> Pets { get; set; }

        [BindProperty]
        
        public FamilyAllergen Allergens { get; set; }

        [BindProperty]
        public FamilyRooms Rooms { get; set; }
        public inputDetailsModel(AppDbContext db, UserManager<ApplicationUser> um)
        {
            _db = db;
            _usermanager = um;
        }

        public async Task OnGetAsync()
        {
            var user = await _usermanager.GetUserAsync(User);
            details = await _db.Families.SingleOrDefaultAsync(f => f.Email == user.Email);
            Pets = _db.FamilyPets.Where(p => p.FamilyID == details.FamilyID).ToList();
        }

            public async Task<IActionResult> OnPostAsync()
            {
            if (!ModelState.IsValid) 
            { 
                return Page(); 
            }
            //_db.Attach(details).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            var user = await _usermanager.GetUserAsync(User);
            var updateDBrecord = await _db.Families.SingleOrDefaultAsync(f => f.Email == user.Email);
            var updateDBrecordRooms =  _db.FamilyRooms.FirstOrDefault(f => f.FamilyID == updateDBrecord.FamilyID);
            var updateDBrecordPets =  _db.FamilyPets.Where(f => f.FamilyID == updateDBrecord.FamilyID).ToList();
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
            //_db.Attach(details).State = EntityState.Modified;
            try
            {
                //might have to iterate through as list

                
                _db.Families.Update(updateDBrecord);
                _db.FamilyAllergen.Update(updateDBrecordAllergens);
               _db.FamilyRooms.Update(updateDBrecordRooms);
                await _db.SaveChangesAsync(); 
                return RedirectToPage("/Family/ViewDetails", new { familyID = details.FamilyID});
            }

            catch (Exception e)
            {
                throw new Exception($"Family {details.FamilyID} could not be made", e);
                
            }

            return Page();
        }


        /*public async Task<IActionResult> OnPostDeleteAsync(int PetID) {
            Pets.RemoveAt(PetID);
            _db.FamilyPets.UpdateRange(Pets);
            try {
                await _db.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e) {
                throw new Exception($"PetID could not be deleted: ", e);
            }




            return Page();

        }*/
    }
}

