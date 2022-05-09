using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBestFlight.Data;
using TheBestFlight.Service;

namespace TheBestFlight.Pages
{
    public class RisultatoModel : PageModel
    {
        [Inject]
        public IScrapingRepository scrapingRepository { get; set; }
        private readonly AppDbContext _context;
        public RisultatoModel(IScrapingRepository scrapingRepository, AppDbContext context)
        {
            this.scrapingRepository = scrapingRepository;
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(string? codiceAeroporto)
        {
            

            return Page();
        }
        //public async Task<IActionResult> OnPostAsync(string? aeroporto)
        //{
        //}
    }
}
