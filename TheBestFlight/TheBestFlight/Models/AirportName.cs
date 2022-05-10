using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBestFlight.Models
{
    public class AirportName
    {
        public string alpha2countryCode { get; set; }
        public string iataCode { get; set; }
        public string icaoCode { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string name { get; set; }
    }
}
