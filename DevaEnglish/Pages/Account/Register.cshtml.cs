using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DevaEnglish.Data;

namespace DevaEnglish.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterUser Input { get; set; }

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;


        public RegisterModel(UserManager<ApplicationUser> um,
            SignInManager<ApplicationUser> sm)

        {
            _signInManager = sm;
            _userManager = um;

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.UserName, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    //await _userManager.AddToRoleAsync(user, "Member");
                    //FreshBasket();
                    //NewCustomer(Input.Email);
                    //await _db.SaveChangesAsync();
                    return RedirectToPage("/Homepage");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }      
    }
}
