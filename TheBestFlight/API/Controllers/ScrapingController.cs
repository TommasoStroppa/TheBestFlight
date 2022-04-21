using API.Functions;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScrapingController : ControllerBase
    {
        private readonly IScrapingRepository scrapingRepository;
        public ScrapingController(IScrapingRepository scrapingRepository)
        {
            this.scrapingRepository = scrapingRepository;
        }
        [HttpGet("ExtractCheapestFlights/{departure}")]
        public async Task<List<string>> ExtractCheapestFlights(string departure)
        {
            RootCheapestFlights eleString = await scrapingRepository.ExtractCheapestFlights(departure);
            return null;
        }
    }
}
