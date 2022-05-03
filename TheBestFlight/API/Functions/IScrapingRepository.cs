using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Functions
{
    public interface IScrapingRepository
    {
        Task<List<CheapestDestination>> ExtractCheapestFlights(string departure);
        Task<Airline> ExtractAirlineInfo(string iata);
    }
}
