using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheBestFlight.Models
{
    public class Tratta
    {
        [Key]
        public int ID { get; set; }
        public string IATA_partenza { get; set; }
        public string IATA_destinazione { get; set; }
    }
}
