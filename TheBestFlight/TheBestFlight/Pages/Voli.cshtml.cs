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
        public List<CheapestDestination> eleOrdinato { get; set; }
        public async Task<IActionResult> OnGetAsync(string? codiceAeroporto)
        {
            if (codiceAeroporto == null)
            {
                return NotFound();
            }

            eleDestinazioni = await scrapingRepository.ExtractCheapestFlights(codiceAeroporto);
            foreach(var item in eleDestinazioni)
            {
                int priceMinItem = item.cheapestFlights.Min(p => p.price);
                int priceMin = 1000;
                foreach (var min in eleOrdinato)
                {
                    int minimo = min.cheapestFlights.Min(p => p.price);
                    if (minimo<priceMin)
                    {
                        priceMin = minimo;
                    }                    
                }
                if (priceMin != 0 && priceMin > priceMinItem)
                {
                    eleOrdinato.Insert(0, item);
                }                
            }
            //eleOrdinato = eleDestinazioni.OrderBy(p => p.cheapestFlights.ToList() == p.cheapestFlights.OrderByDescending(p => p.price).ToList()).ToList();

            if (eleDestinazioni.Count == 0)
            {
                return NotFound();
            }

            return Page();
        }
        //public async Task<IActionResult> OnPostAsync(string? aeroporto)
        //{
        //}
    }
}
