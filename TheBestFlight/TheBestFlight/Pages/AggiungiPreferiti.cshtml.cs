using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBestFlight.Data;
using TheBestFlight.Service;
using Newtonsoft.Json;
using TheBestFlight.Models;
using Microsoft.AspNetCore.Authorization;

namespace TheBestFlight.Pages
{
    public class AggiungiPreferitiModel : PageModel
    {
        [Inject]
        public IScrapingRepository scrapingRepository { get; set; }
        private readonly AppDbContext _context;
        public AggiungiPreferitiModel(IScrapingRepository scrapingRepository, AppDbContext context)
        {
            this.scrapingRepository = scrapingRepository;
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(string? volo)
        {            
            if (User.Identity.Name != null)
            {
                Tratta tratta = JsonConvert.DeserializeObject<Tratta>(volo);

                if (tratta == null)
                {
                    return NotFound();
                }

                Associazione associazione = new Associazione
                {
                    ID_Tratta = tratta.IATA_partenza+tratta.IATA_destinazione,
                    Username_Utente = User.Identity.Name
                };

                _context.eleTratte.Add(tratta);
                _context.eleAssociazioni.Add(associazione);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("/Preferiti");
                }
                catch
                {
                    return NotFound();
                }
            }
            else
            {
                return RedirectToPage("/Index");
            }            
        }
    }
}
