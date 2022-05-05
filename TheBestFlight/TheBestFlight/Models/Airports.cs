using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBestFlight.Models
{
    public class AirportResult
    {
        public bool isActive { get; set; }
        public string AirportName { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string AirportCode { get; set; }
        public string citycode { get; set; }
        public string lat { get; set; }
        public string @long { get; set; }
        public string timzone { get; set; }
        public string cityunicode { get; set; }
        public string zone { get; set; }
        public string CountryCode { get; set; }
        public string id { get; set; }
    }

    public class Airports
    {
        public List<AirportResult> results { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
        public int totalPages { get; set; }
        public int totalResults { get; set; }
    }
}
