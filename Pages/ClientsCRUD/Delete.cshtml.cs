using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Netpobre.Models;

namespace Netpobre.Pages.ClientsCRUD
{
    [Authorize(Policy = "isAdmin")]

    public class DeleteModel : PageModel
    {
            private readonly ApplicationDbContext _context;

            public DeleteModel(ApplicationDbContext context)
            {
                _context = context;
            }

            [BindProperty]
            public Client Clients { get; set; } = default!;

            public async Task<IActionResult> OnGetAsync(int? id)
            {
                if (id == null || _context.Clients == null)
                {
                    return NotFound();
                }

                var cliente = await _context.Clients.FirstOrDefaultAsync(m => m.ID == id);

                if (cliente == null)
                {
                    return NotFound();
                }
                else
                {
                    Clients = cliente;
                }
                return Page();
            }

            public async Task<IActionResult> OnPostAsync(int? id)
            {
                if (id == null || _context.Clients == null)
                {
                    return NotFound();
                }
                var cliente = await _context.Clients.FindAsync(id);

                if (cliente != null)
                {
                    Clients = cliente;
                    _context.Clients.Remove(Clients);
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("./Index");
            }
        }
    }

