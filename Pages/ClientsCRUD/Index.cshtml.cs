using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Netpobre.Models;
using Azure.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Netpobre;
using System.ComponentModel.DataAnnotations;
using Netpobre.Migrations;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;

namespace Netpobre.Pages.ClientsCRUD
{
    [Authorize(Policy = "isAdmin")]

    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IList<string> EmailsAdmin { get; set; }

        public IndexModel(ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IList<Client> Clients { get; set; } = default!;

        public async Task OnGetAsync(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                TempData["AdminMessage"] = "Bem-vindo, administrador!";
            }
            else
            {
                
            }
        }

    }
}