using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TheBestFlight.Data;
using TheBestFlight.Models;
using TheBestFlight.Service;

namespace TheBestFlight.Pages
{
    public class RimuoviPreferitiModel : PageModel
    {
        private readonly IScrapingRepository scrapingRepository;
        private readonly AppDbContext _context;
        public RimuoviPreferitiModel(IScrapingRepository scrapingRepository, AppDbContext context)
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

        public async Task<IActionResult> OnGetAsync(string? volo)
        {
            if (volo == null)
                return NotFound();

            Tratta tratta = JsonConvert.DeserializeObject<Tratta>(volo);
            Tratta tratta2 = _context.eleTratte.Where(p => p.IATA_partenza == tratta.IATA_partenza && p.IATA_destinazione == tratta.IATA_destinazione).FirstOrDefault();
            var Associazione = _context.eleAssociazioni.FirstOrDefault(p => p.ID_Tratta == tratta.IATA_partenza+tratta.IATA_destinazione);

            _context.eleTratte.Remove(tratta2);
            _context.eleAssociazioni.Remove(Associazione);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
            catch
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
