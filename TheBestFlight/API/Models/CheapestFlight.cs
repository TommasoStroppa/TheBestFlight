using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class RootCheapestFlights
    {
        public bool success { get; set; }
        public object data { get; set; }
        public string currency { get; set; }
    }
    public class CheapestDestination
    {
        public string destination { get; set; }
        public List<CheapestFlight> cheapestFlights { get; set; }
    }
    public class CheapestFlight
    {
        public int price { get; set; }
        public string airline { get; set; }
        public int flight_number { get; set; }
        public DateTime departure_at { get; set; }
        public DateTime return_at { get; set; }
        public DateTime expires_at { get; set; }
    }
}
