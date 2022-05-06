using API.Functions;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public async Task<List<Airline>> ExtractAirlineInfo(string iata)
        {
            List<Airline> airlines = await scrapingRepository.ExtractAirlineInfo(iata);
            return airlines;
        }
        [HttpGet("SearchAirports/{keyword}")]
        public async Task<Airports> SearchAirports(string keyword)
        {
            Airports airports = await scrapingRepository.SearchAirports(keyword);            
            return airports;
        }
        [HttpGet("TranslateString/{text}")]
        public async Task<string> TranslateString(string text)
        {
            string traduzione = await scrapingRepository.TranslateString(text);
            return traduzione;
        }
    }
}
