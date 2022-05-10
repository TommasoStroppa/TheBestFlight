using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBestFlight.Models;

namespace TheBestFlight.Service
{
    public interface IScrapingRepository
    {
        Task<List<CheapestDestination>> ExtractCheapestFlights(string departure);
        Task<List<CheapestDestination>> ExtractCheapestFlightsArrival(string departure, string arrival);
        Task<List<Airline>> ExtractAirlineInfo(string iata);
        Task<Airports> SearchAirports(string keyword);
        Task<string> TranslateString(string text);
        Task<AirportName> AirportName(string code);
    }
}
