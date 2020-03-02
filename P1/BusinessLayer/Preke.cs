using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore
{
    class Preke
    {
        public string Pavadinimas { get; set; }
        public Guid UnikalusNumeris { get; set; }
        public int PirkimoKaina { get; set; }
        public int PardavimoKaina { get; set; }
        public int Likutis { get; set; }
        public PrekesTipasEnum PrekesTipas { get; set; }
        public Imone imonePirkejas { get; set; }
    }
}
