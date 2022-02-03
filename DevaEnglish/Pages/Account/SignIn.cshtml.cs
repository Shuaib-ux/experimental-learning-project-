using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DevaEnglish.Data;          
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DevaEnglish.Pages.Account
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public SignInUser Input { get; set; }

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SignInModel(SignInManager<ApplicationUser> sm, UserManager<ApplicationUser> um)
        {
            _signInManager = sm;
            _userManager = um;
        }

        public IActionResult OnGet() {
            //checks if the user is signed, 
            if (User.Identity.IsAuthenticated) {
                //if so go straight to the homepage
                 return RedirectToPage("/Homepage");
            
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                
                if (user != null)
                {
                    await _signInManager.SignInAsync(user, true);

                    return RedirectToPage("/Homepage");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email does not exist");
                }
                

                //var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: false);

                //if (result.Succeeded)
                //{
                //return RedirectToPage("/Index");
                //}
                //else
                //{
                //ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                //}
                //return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
