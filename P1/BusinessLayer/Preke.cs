using System;
using System.Collections.Generic;
using System.Text;

namespace P1
{
    class Preke
    {
        public string Pavadinimas { get; set; }
        public Guid UnikalusNumeris { get; set; }
        public int PirkimoKaina { get; set; }
        public int PardavimoKaina { get; set; }

        public PrekesTipasEnum PrekesTipas { get; set; }
    }
}
