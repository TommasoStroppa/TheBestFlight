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
    public class AeroportoModel : PageModel
    {
        [Inject]
        public IScrapingRepository scrapingRepository { get; set; }
        private readonly AppDbContext _context;

        public AeroportoModel(IScrapingRepository scrapingRepository, AppDbContext context)
        {
            this.scrapingRepository = scrapingRepository;
            _context = context;
        }
        [BindProperty]
        public string citta { get; set; }
        [BindProperty]
        public List<AirportResult> eleAeroporti { get; set; }
        [BindProperty]
        public string aeroporto { get; set; }
        [BindProperty]
        public string codiceAeroporto { get; set; }
        public async Task<IActionResult> OnGetAsync(string? citta)
        {
            if (citta == null)
                return NotFound();

            citta = citta[0].ToString().ToUpper() + citta.Substring(1, citta.Length-1).ToLower();
            citta = await scrapingRepository.TranslateString(citta);
            Airports aeroporti = await scrapingRepository.SearchAirports(citta);
            eleAeroporti = aeroporti.results;

            if(eleAeroporti.Count==0)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string? aeroporto)
        {
            if(aeroporto == null)
            {
                return NotFound();
            }

            string codiceAeroporto = aeroporto.Split('-')[2].Trim();

            if (codiceAeroporto == null)
                return NotFound();

            return RedirectToPage("/Voli", new { codiceAeroporto = codiceAeroporto });
        }
    }
}
