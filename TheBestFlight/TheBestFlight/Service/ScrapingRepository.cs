using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TheBestFlight.Models;

namespace TheBestFlight.Service
{
    public class ScrapingRepository : IScrapingRepository
    {
        private readonly HttpClient httpClient;
        public ScrapingRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<CheapestDestination>> ExtractCheapestFlights(string departure)
        {
            return await httpClient.GetFromJsonAsync<List<CheapestDestination>>(@$"Scraping/ExtractCheapestFlights/{departure}");
        }
        public async Task<List<CheapestDestination>> ExtractCheapestFlightsArrival(string departure, string arrival)
        {
            return await httpClient.GetFromJsonAsync<List<CheapestDestination>>(@$"Scraping/ExtractCheapestFlightsArrival/{departure}/{arrival}");
        }
        public async Task<List<Airline>> ExtractAirlineInfo(string iata)
        {
            return await httpClient.GetFromJsonAsync<List<Airline>>(@$"Scraping/ExtractAirlineInfo/{iata}");
        }
        public async Task<Airports> SearchAirports(string keyword)
        {
            return await httpClient.GetFromJsonAsync<Airports>(@$"Scraping/SearchAirports/{keyword}");
        }
        public async Task<string> TranslateString(string text)
        {
            return await httpClient.GetStringAsync(@$"Scraping/TranslateString/{text}");
        }
        public async Task<AirportName> AirportName(string code)
        {
            return await httpClient.GetFromJsonAsync<AirportName>(@$"Scraping/AirportName/{code}");
        }
    }
}
