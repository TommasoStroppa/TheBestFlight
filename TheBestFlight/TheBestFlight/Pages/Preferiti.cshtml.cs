using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBestFlight.Data;
using TheBestFlight.Models;
using TheBestFlight.Service;

namespace TheBestFlight.Pages
{
    [Authorize]
    public class PreferitiModel : PageModel
    {
        private readonly IScrapingRepository scrapingRepository;
        private readonly AppDbContext _context;
        public PreferitiModel(IScrapingRepository scrapingRepository, AppDbContext context)
        {
            this.scrapingRepository = scrapingRepository;
            _context = context;
            eleTratte = _context.eleTratte.ToList();
            eleAssociazioni = _context.eleAssociazioni.ToList();
        }
        public List<CheapestDestination> eleDestinazioni { get; set; }
        public List<Tratta> eleTratte { get; set; }
        public List<Tratta> eleTratteUtente { get; set; }
        public List<Associazione> eleAssociazioniUtente { get; set; }
        public List<Associazione> eleAssociazioni { get; set; }
        public List<AirportName> eleNomi { get; set; }
        public Tratta tratta { get; set; }
        public string codiceAeroporto { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            eleNomi = new List<AirportName>();
            eleTratteUtente = new List<Tratta>();
            eleAssociazioniUtente = eleAssociazioni.Where(p => p.Username_Utente == User.Identity.Name).ToList();
            foreach (var associa in eleAssociazioniUtente)
            {
                var tratta = eleTratte.Where(p => p.IATA_partenza+p.IATA_destinazione == associa.ID_Tratta).FirstOrDefault();
                if (tratta != null)
                {
                    eleTratteUtente.Add(tratta);
                }
            }

            if (eleTratteUtente == null)
            {
                return NotFound();
            }
            
            foreach(var item in eleTratteUtente)
            {
                eleDestinazioni = await scrapingRepository.ExtractCheapestFlightsArrival(item.IATA_partenza, item.IATA_destinazione);
            }

            foreach (var item in eleDestinazioni)
            {
                eleNomi.Add(await scrapingRepository.AirportName(item.destination));
            }

            return Page();
        }
    }
}
