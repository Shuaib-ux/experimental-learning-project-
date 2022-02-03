using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using DevaEnglish.Data;

namespace DevaEnglish.Pages.Account
{
    public class SignOutModel : PageModel
    {

        private readonly SignInManager<ApplicationUser> _signInManager;

        public SignOutModel(SignInManager<ApplicationUser> sm)
        {
            _signInManager = sm;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Account/SignIn");
        }
    }
}
