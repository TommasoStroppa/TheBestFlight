using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheBestFlight.Models
{
    public class Associazione
    {
        [Key]
        public int ID { get; set; }
        public string Username_Utente { get; set; }
        public string ID_Tratta { get; set; }
    }
}
