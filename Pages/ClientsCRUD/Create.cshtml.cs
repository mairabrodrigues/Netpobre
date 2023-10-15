using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Netpobre.Models;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Netpobre.Pages.ClientsCRUD
{
   public class CreateModel : PageModel
    {
        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;




        [BindProperty]
        public Client Clients { get; set; } = default!;

        public CreateModel(ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        public IActionResult OnGet()
        {
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            
                _context.Clients.Add(Clients);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
           
    }
}