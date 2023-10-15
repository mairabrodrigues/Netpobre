using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Netpobre.Models;

namespace Netpobre.Pages.SeriesCRUD
{
    

    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Series> Series { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Series != null)
            {
                Series = await _context.Series.ToListAsync();
            }
        }
    }
}
