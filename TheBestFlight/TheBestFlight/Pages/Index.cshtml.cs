using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBestFlight.Data;
using TheBestFlight.Service;

namespace TheBestFlight.Pages
{
    public class IndexModel : PageModel
    {
        [Inject]
        public IScrapingRepository scrapingRepository { get; set; }
        private readonly AppDbContext _context;

        public IndexModel(IScrapingRepository scrapingRepository, AppDbContext context)
        {
            this.scrapingRepository = scrapingRepository;
            _context = context;
        }
        [BindProperty]
        public string citta { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string? citta)
        {
            if (citta == null)
                return NotFound();
                        
            return RedirectToPage("/Aeroporto", new { citta=citta });
        }
    }
}
