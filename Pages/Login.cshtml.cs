using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Netpobre.Models;
using System.ComponentModel.DataAnnotations;

namespace Netpobre.Pages
{
    public class LoginModel : PageModel
    {
        public class DadosLogin
        {
            [Required]
            [EmailAddress]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [Display(Name ="Remind me")]
            
            public bool Remind { get; set; }
        }
        private readonly SignInManager<AppUser> _signInManager;
       
        public LoginModel (SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            
        }
        [BindProperty]
        public DadosLogin Dados {  get; set; }

        public string ReturnUrl { get; set; }

        [TempData] 
        public string ErrorMessage { get; set;}

        public async Task OnGetAsync (string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            returnUrl = returnUrl ?? Url.Content ("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;
        }
        public async Task <IActionResult> OnPostAsync (string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Dados.Email,Dados.Password,Dados.Remind, lockoutOnFailure:false);
                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login. Try again.");
                    return Page();
                }
            }
            return Page();
        }
    }
}
