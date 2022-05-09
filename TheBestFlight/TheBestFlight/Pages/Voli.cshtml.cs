using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBestFlight.Data;
using TheBestFlight.Models;
using TheBestFlight.Service;

namespace TheBestFlight.Pages
{
    public class VoliModel : PageModel
    {
        [Inject]
        public IScrapingRepository scrapingRepository { get; set; }
        private readonly AppDbContext _context;
        public VoliModel(IScrapingRepository scrapingRepository, AppDbContext context)
        {
            this.scrapingRepository = scrapingRepository;
            _context = context;
        }
        [BindProperty]
        public string aeroporto { get; set; }
        [BindProperty]
        public string codiceAeroporto { get; set; }
        [BindProperty]
        public List<CheapestDestination> eleDestinazioni { get; set; }
        [BindProperty]
        public CheapestFlight voloscelto { get; set; }
        public CheapestFlight volo { get; set; }
        public async Task<IActionResult> OnGetAsync(string? codiceAeroporto)
        {
            if (codiceAeroporto == null)
            {
                return NotFound();
            }

            eleDestinazioni = await scrapingRepository.ExtractCheapestFlights(codiceAeroporto);
            int min = 0;
            List<int> minimi = new List<int>();
            int num = eleDestinazioni.Count;
            for (int i = 0; i < num; i++)
            {
                eleDestinazioni[i].cheapestFlights = eleDestinazioni[i].cheapestFlights.OrderBy(a => a.price).ToList();
            }
            eleDestinazioni = eleDestinazioni.OrderBy(a => a.cheapestFlights[0].price).ToList();
            
            if (eleDestinazioni.Count == 0)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(CheapestFlight voloscelto)
        {
            return Page();
        }
    }
}
