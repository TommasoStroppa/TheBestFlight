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
        public async Task<List<CheapestDestination>> ExtractCheapestFlights(string departure)
        {
            List<CheapestDestination> eleDestinazioni = await scrapingRepository.ExtractCheapestFlights(departure);
            return eleDestinazioni;
        }
        [HttpGet("ExtractAirlineInfo/{iata}")]
        public async Task<Airline> ExtractAirlineInfo(string iata)
        {
            Airline airline = await scrapingRepository.ExtractAirlineInfo(iata);
            return airline;
        }
    }
}
