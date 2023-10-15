using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Netpobre.Models;

namespace Netpobre.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private ApplicationDbContext _context;

        public IList<Series> Serie;
        
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IList<Series> Series { get;  set; }
        public async Task OnGetAsync([FromQuery] string Search)
        {
            if (string.IsNullOrEmpty(Search))
            {
                Serie = await _context.Series.ToListAsync<Series>();
               
            }
            else
            {
                Serie = await _context.Series.Where(p => p.Show.ToUpper().Contains(Search)).ToListAsync();
            }
           

    }
        }
    }
