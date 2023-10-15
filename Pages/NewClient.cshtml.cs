using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Netpobre;
using Netpobre.Models;
using System.ComponentModel.DataAnnotations;

namespace Netpobre.Pages;
    public class NewClientModel : PageModel
    {
        public class Passwords
        {
            [Required(ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; } = default!;
        }

        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public NewClientModel(ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public Client Clients { get; set; } = default!;
        [BindProperty]
        public Passwords UserPassword { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Create the new client.
                var user = new AppUser
                {
                    UserName = Clients.Email,
                    Email = Clients.Email,
                };

                var result = await _userManager.CreateAsync(user, UserPassword.Password);

                if (result.Succeeded)
                {
                    // Add the client to the database.
                    _context.Clients.Add(Clients);
                    await _context.SaveChangesAsync();

                    // Redirect to the finish page.
                    return RedirectToPage("./Finish");
                }
                else
                {
                    // Add the user creation errors to the model state.
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Erro", error.Description);
                    }
                }
            }

            // Return to the page if the model state is invalid.
            return Page();
        }
    }
    
