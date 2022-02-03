using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevaEnglish.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DevaEnglish.Pages
{
    public class IndexModel : PageModel
    {
        private AppDbContext _db;
        private readonly UserManager<ApplicationUser> _usermanager;

     
       
        public IndexModel(AppDbContext db, UserManager<ApplicationUser> um) {
            _db = db;
            _usermanager = um;
            

        }
        public void  OnGet(int availabilityResponse, int bookingResponse)
        {
            TempData["bookingResponse"] = bookingResponse;
            TempData["availabilityResponse"] = availabilityResponse;
           

        }
        
    }
}
