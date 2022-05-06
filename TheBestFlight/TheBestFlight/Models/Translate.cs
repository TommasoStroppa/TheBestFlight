using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBestFlight.Models
{
    public class Data
    {
        public List<Translation> translations { get; set; }
    }

    public class Translate
    {
        public Data data { get; set; }
    }

    public class Translation
    {
        public string translatedText { get; set; }
    }
}
