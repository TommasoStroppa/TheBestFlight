using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Airline
    {
        public object alliance { get; set; }
        public string iata_code { get; set; }
        public string icao_code { get; set; }
        public bool low_cost_carrier { get; set; }
        public string name { get; set; }
        public string website { get; set; }
    }
}
